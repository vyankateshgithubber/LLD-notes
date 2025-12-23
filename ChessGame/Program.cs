public class ChessDemo
{
    public static void Main(string[] args)
    {
        ChessGame game = new ChessGame(new Player(Color.White), new Player(Color.Black));
        game.StartGame();
        
    }
}