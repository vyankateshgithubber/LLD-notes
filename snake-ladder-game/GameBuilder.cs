using System.Reflection.Metadata;

public class GameBuilder
{
    private int boardSize = 100;
    private Queue<Player> players;
    private List<Box> boxes;
    private Dice dice = new Dice();
    private Board board;

    public GameBuilder SetBoardSize(int size, List<Box> boxess)
    {
        this.boardSize = size;
        this.boxes = boxess;
        return this;
    }

    public GameBuilder AddPlayerw(List<string> names)
    {
        players = new Queue<Player>();
        foreach (var name in names)
        {
            players.Enqueue(new Player(name));
        }
        return this;
    }
    public Game Build()
    {
        board = new Board(boardSize, boxes);
        return new Game(board, players, dice);
    }
}