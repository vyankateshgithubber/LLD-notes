public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public BalanceSheet BalanceSheet { get; private set; }
    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        BalanceSheet = new BalanceSheet(this);
    }
}