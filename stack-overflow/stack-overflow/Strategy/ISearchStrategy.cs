using System.Collections.Generic;
using System.Linq;
using StackOverflow.Models.Content;

namespace StackOverflow.Strategy
{
    public interface ISearchStrategy
    {
        IEnumerable<Question> Filter(IEnumerable<Question> questions);
    }
}
