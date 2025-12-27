public interface ISplitStrategy
{
     List<Split> GetSplits(decimal totalAmount, List<User> users);
}