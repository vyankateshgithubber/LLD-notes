using System.Linq.Expressions;

public class Board
{
    public int Size { get; private set; }
    
    private Dictionary<int, int> snakesLadders;

    public Board(int size,List<Box> boxess)
    {
        Size = size;
        snakesLadders = new Dictionary<int, int>();
        foreach (var box in boxess)
        {
            snakesLadders[box.Start] = box.End;
        }
    }
    public int GetNewPosition(int newPosition)
    {

        // Check for snakes or ladders
        if (snakesLadders.ContainsKey(newPosition))
        {
            return snakesLadders[newPosition];
        }

        return newPosition;
    }
}