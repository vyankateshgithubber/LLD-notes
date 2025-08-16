using System.Collections.Concurrent;
using StackOverflow.Enums;
using StackOverflow.Models;
using StackOverflow.Models.Content;
using StackOverflow.Observers;

public abstract class Post : Content
{
    private int voteCount = 0;
    private readonly ConcurrentDictionary<string, VoteType> voters = new ConcurrentDictionary<string, VoteType>();
    private readonly List<Comment> comments = new List<Comment>();
    // list of people observing this post
    private readonly List<IPostObserver> observers = new List<IPostObserver>();
    private readonly object lockObject = new object();

    public Post(string body, User author) : base(Guid.NewGuid().ToString() , body, author)
    {
    }

    public void AddObserver(IPostObserver observer)
    {
        observers.Add(observer);
    }

    protected void NotifyObservers(Event eventObj)
    {
        foreach (var observer in observers)
        {
            observer.OnPostEvent(eventObj);
        }
    }
    public void Vote(User user, VoteType voteType)
    {
        lock (lockObject)
        {
            string userId = user.GetId().ToString();
            if (voters.TryGetValue(userId, out VoteType existingVote) && existingVote == voteType)
            {
                return; // User has already voted with the same type
            }
            int scoreChange = 0;
            if (voters.ContainsKey(userId))
            {
                scoreChange = voteType switch
                {
                    VoteType.UPVOTE => 1,
                    VoteType.DOWNVOTE => -1,
                    _ => 0
                };
            }
            else
            {
                scoreChange = voteType switch
                {
                    VoteType.UPVOTE => 1,
                    VoteType.DOWNVOTE => -1,
                    _ => 0
                };
            }

            voters[userId] = voteType;
            voteCount += scoreChange;
            EventType eventType;
            if (this is Question)
            {
                eventType = (voteType == VO  ) ? EventType.QuestionUpvoted : EventType.QuestionDownvoted;
            }
            else
            {
                eventType = (voteType == VoteType.Upvote) ? EventType.AnswerUpvoted : EventType.AnswerDownvoted;    
            }
            NotifyObservers(new Event(eventType, this, user));
        }
    }

}