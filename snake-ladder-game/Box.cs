public  abstract class Box
{
    public int Start { get; private set; }
    public int End { get; private set; }

    public Box(int start, int end)
    {
        Start = start;
        End = end;
    }
}

//Snakes and Ladders will inherit from Box class
public class Snake : Box
{
    public Snake(int start, int end) : base(start, end)
    {
        if (start <= end)
        {
            throw new ArgumentException("Snake's head must be at a higher position than its tail.");
        }
    }
}

public class Ladder : Box
{
    public Ladder(int start, int end) : base(start, end)
    {
        if (start >= end)
        {
            throw new ArgumentException("Ladder's bottom must be at a lower position than its top.");
        }
    }
}