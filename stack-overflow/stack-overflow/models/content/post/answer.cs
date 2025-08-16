using System;
using StackOverflow.Models;

namespace StackOverflow.Models.Content
{
    public class Answer : Post
    {
        private bool isAccepted = false;

        public Answer(string body, User author)
            : base(body, author)
        {
        }

        public void SetAccepted(bool accepted)
        {
            isAccepted = accepted;
        }

        public bool IsAcceptedAnswer() { return isAccepted; }
    }
}