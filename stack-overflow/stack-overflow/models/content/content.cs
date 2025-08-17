using System;
using StackOverflow.Models;

namespace StackOverflow.Models.Content
{
    public abstract class Content
    {
        protected readonly string id;
        protected readonly string body;
        protected readonly User author;

        protected readonly DateTime createdTime;

        public Content(string id, string body, User author)
        {
            this.id = id;
            this.body = body;
            this.author = author;
            createdTime = DateTime.Now;
        }

        public string GetId() => id;

        public string GetBody() => body;

        public User GetAuthor() => author;

        public DateTime GetCreatedTime() => createdTime;
    }
}