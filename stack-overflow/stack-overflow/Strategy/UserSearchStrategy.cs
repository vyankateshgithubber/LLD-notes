using System.Collections.Generic;
using System.Linq;
using StackOverflow.Models;
using StackOverflow.Models.Content;

namespace StackOverflow.Strategy
{
    public class UserSearchStrategy : ISearchStrategy
    {
        private readonly User user;

        public UserSearchStrategy(User user)
        {
            this.user = user;
        }

        public IEnumerable<Question> Filter(IEnumerable<Question> questions)
        {
            return questions.Where(q => q.GetAuthor().GetId() == user.GetId());
        }
    }
}
