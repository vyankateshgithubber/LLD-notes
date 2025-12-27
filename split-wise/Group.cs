public class Group
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<User> Members { get; private set; }

    public Group(int id, string name)
    {
        Id = id;
        Name = name;
        Members = new List<User>();
    }

    public void AddMember(User user)
    {
        if (!Members.Contains(user))
        {
            Members.Add(user);
        }
    }

    public void RemoveMember(User user)
    {
        if (Members.Contains(user))
        {
            Members.Remove(user);
        }
    }
}