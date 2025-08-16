using System.Collections.Generic;
using System.Linq;
using StackOverflow.Models;
using StackOverflow.Models.Content;

namespace StackOverflow.Strategy
{
    public class TagSearchStrategy : ISearchStrategy
    {
        private readonly Tag tag;

        public TagSearchStrategy(Tag tag)
        {
            this.tag = tag;
        }

        public IEnumerable<Question> Filter(IEnumerable<Question> questions)
        {
            return questions.Where(q => q.GetTags().Contains(tag));
        }
    }
}
