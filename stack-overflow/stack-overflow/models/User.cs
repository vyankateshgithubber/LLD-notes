namespace StackOverflow.Models
{
    public class User
{
    private readonly int Id;
    private readonly string name;

    private int reputation;
    private readonly object reputationLock = new object();

    public User(int id, string name)
    {
        Id = id;
        this.name = name;
        reputation = 0;
    }

    public void UpdateReputation(int change)
    {
        lock (reputationLock)
        {
            reputation += change;
        }
    }
    public int GetId() => Id;

    public string GetName() => name;
    
    public int GetReputation()
    {
        lock (reputationLock)
        {
            return reputation;
    }
}
}}