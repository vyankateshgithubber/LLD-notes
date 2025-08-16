using StackOverflow.Models;
using StackOverflow.Models.Content;

public class Comment : Content
{
    public Comment(string body, User author) : base(Guid.NewGuid().ToString(), body, author)
    {
        
    }
}