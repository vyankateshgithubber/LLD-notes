public class Dice
{
    int minValue = 1;
    int maxValue = 6;
    private static readonly Random random = new Random();

    public int Roll()
    {
        return random.Next(minValue, maxValue + 1); // Returns a number between 1 and 6
    }
}