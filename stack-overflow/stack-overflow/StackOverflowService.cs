using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.Models;
using StackOverflow.Models.Content;
using StackOverflow.Enums;
using StackOverflow.Strategy;
using StackOverflow.Observers;

namespace StackOverflow
{
    public class StackOverflowService
    {
        private readonly List<User> users;
        private readonly List<Question> questions;
        private readonly List<Answer> answers;
        private int nextUserId = 1;
        private int nextContentId = 1;
        private readonly ReputationManager reputationManager;

        public StackOverflowService()
        {
            users = new List<User>();
            questions = new List<Question>();
            answers = new List<Answer>();
            reputationManager = new ReputationManager();
        }

        public User CreateUser(string name)
        {
            var user = new User(nextUserId++, name);
            users.Add(user);
            return user;
        }

        public Question PostQuestion(int userId, string title, string body, HashSet<Tag> tags)
        {
            var user = GetUserById(userId);
            var question = new Question(nextContentId++, title, body, user, tags);
            questions.Add(question);
            reputationManager.NotifyEvent(new Event(EventType.QUESTION_POSTED, user));
            return question;
        }

        public Answer PostAnswer(int userId, int questionId, string body)
        {
            var user = GetUserById(userId);
            var question = GetQuestionById(questionId);
            var answer = new Answer(nextContentId++, body, user);
            answers.Add(answer);
            reputationManager.NotifyEvent(new Event(EventType.ANSWER_POSTED, user));
            return answer;
        }

        public void VoteOnPost(int voterId, int contentId, VoteType voteType)
        {
            var content = GetContentById(contentId);
            if (content != null)
            {
                var voter = GetUserById(voterId);
                var author = content.GetAuthor();
                reputationManager.NotifyEvent(new Event(voteType == VoteType.UPVOTE ? 
                    EventType.UPVOTE_RECEIVED : EventType.DOWNVOTE_RECEIVED, author));
            }
        }

        public void AcceptAnswer(int questionId, int answerId)
        {
            var question = GetQuestionById(questionId);
            var answer = GetAnswerById(answerId);
            question.SetAcceptedAnswer(answer);
            answer.MarkAsAccepted();
            reputationManager.NotifyEvent(new Event(EventType.ANSWER_ACCEPTED, answer.GetAuthor()));
        }

        public List<Question> SearchQuestions(List<ISearchStrategy> strategies)
        {
            if (strategies == null || !strategies.Any())
                return questions;

            var result = questions.AsEnumerable();
            foreach (var strategy in strategies)
            {
                result = strategy.Filter(result);
            }
            return result.ToList();
        }

        private User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.GetId() == id) 
                ?? throw new ArgumentException($"User with ID {id} not found");
        }

        private Question GetQuestionById(int id)
        {
            return questions.FirstOrDefault(q => q.GetId() == id)
                ?? throw new ArgumentException($"Question with ID {id} not found");
        }

        private Answer GetAnswerById(string id)
        {
            return answers.FirstOrDefault(a => a.GetId() == id)
                ?? throw new ArgumentException($"Answer with ID {id} not found");
        }

        private Content GetContentById(string id)
        {
            return questions.FirstOrDefault(q => q.GetId() == id) as Content 
                ?? answers.FirstOrDefault(a => a.GetId() == id) as Content
                ?? throw new ArgumentException($"Content with ID {id} not found");
        }
    }
}
