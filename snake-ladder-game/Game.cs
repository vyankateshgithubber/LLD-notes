public class Game
{
    private Board board;
    private Queue<Player> players;
    private Dice dice;
    private Player winner;
    private GameStatus status;

    public Game(Board board, Queue<Player> players, Dice dice)
    {
        this.board = board;
        this.players = players;
        this.dice = dice;
        this.winner = null;
    }

    public void Play()
    {
        if (players.Count < 2)
        {
            throw new InvalidOperationException("At least two players are required to start the game.");
        }
        status = GameStatus.RUNNING;
        while (status == GameStatus.RUNNING)
        {
            var currentPlayer = players.Dequeue();
            TakeTurn(currentPlayer);
            if(status == GameStatus.RUNNING)
            {
                players.Enqueue(currentPlayer);
            }
        }
    }
    private void TakeTurn(Player player)
    {
        int roll = dice.Roll();
        Console.WriteLine($"{player.Name} rolled a {roll}");

        int newPosition = player.Position + roll;
        if (newPosition > board.Size)
        {
            Console.WriteLine($"{player.Name} cannot move, needs exact roll to finish.");
            return;
        }
        if(newPosition == board.Size)
        {
            player.Position = newPosition;
            winner = player;
            status = GameStatus.COMPLETED;
            Console.WriteLine($"{player.Name} has won the game!");
            return;
        }

        int finalPosition = board.GetNewPosition(newPosition);
        if( finalPosition > newPosition)
        {
            Console.WriteLine($"{player.Name} climbed a ladder to {finalPosition}");
        }
        else if(finalPosition < newPosition)
        {
            Console.WriteLine($"{player.Name} moved to {newPosition} via snake/ladder");
        }
        player.Position = finalPosition;
        Console.WriteLine($"{player.Name} moved to position {player.Position}");
        if(roll == 6)
        {
            Console.WriteLine($"{player.Name} rolled a 6 and gets an extra turn!");
            TakeTurn(player);
        }
    }
}