using System;
using System.Collections.Generic;
using StackOverflow.Enums;
using StackOverflow.Models;
using StackOverflow.Models.Content;
using StackOverflow.Observers.Events;


public class Question : Post
{
    private readonly string title;
    private readonly HashSet<Tag> tags;

    private readonly List<Answer> answers = new List<Answer>();
    private Answer? acceptedAnswer;

    public Question(string title, string body, User author, HashSet<Tag> tags) : base(body, author)
    {
        this.title = title;
        this.tags = tags;
        this.acceptedAnswer = null; // Initially, there is no accepted answer
    }

    public void AddAnswer(Answer answer)
    {
        answers.Add(answer);
    }

    public void AcceptAnswer(Answer answer)
    {
        lock (this)
        {
            if (!author.GetId().Equals(answer.GetAuthor().GetId()) && acceptedAnswer == null)
            {
                this.acceptedAnswer = answer;
                answer.SetAccepted(true);
                NotifyObservers(new Event(EventType.ACCEPT_ANSWER, answer.GetAuthor(), this));
            }
        }
    }

    public string GetTitle() { return title; }
    public HashSet<Tag> GetTags() { return tags; }
    public List<Answer> GetAnswers() { return answers; }
}
