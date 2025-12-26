public class Player
{
    public string Name { get; private set; }
    public int Position { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = 0; // Players start at position 0
    }
}