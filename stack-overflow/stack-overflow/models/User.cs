namespace StackOverflow.Models
{
    public class User
    {
        private readonly string Id;
        private readonly string name;

        private int reputation;
        private readonly object reputationLock = new object();

        public User(string name)
        {
            Id = Guid.NewGuid().ToString(); // Unique identifier for the user
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
        public string GetId() => Id;

        public string GetName() => name;

        public int GetReputation()
        {
            lock (reputationLock)
            {
                return reputation;
            }
        }
    }
}