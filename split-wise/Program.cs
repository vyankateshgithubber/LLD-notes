public class SplitWiseApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to SplitWise!");
        // Application logic goes here
        SplitWiseService service = SplitWiseService.GetInstance();
        User alice = new User(1, "Alice", "alice@example.com");
        User bob = new User(2, "Bob", "bob@example.com");
        service.AddUser(alice);
        service.AddUser(bob);
        Group tripGroup = new Group(1, "Trip to Bali");
        tripGroup.AddMember(alice);
        tripGroup.AddMember(bob);
        service.AddGroup(tripGroup);
        Expense expense = new ExpenseBuilder()
            .SetId(1)
            .SetDescription("Hotel Booking")
            .SetTotalAmount(200m)
            .SetPaidBy(alice)
            .AddSplit(bob, 0m)
            .AddSplit(alice, 0m)
            .SetSplitStrategy(new EquallySplitStrategy())
            .Build();

        service.CreateExpense(expense);
        service.ShowBalances("alice@example.com");
        service.ShowBalances("bob@example.com");


    }
    
}