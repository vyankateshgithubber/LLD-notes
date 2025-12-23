using System.IO.Compression;
using System.Runtime.CompilerServices;

public class ChessGame
{
    private Board board;
    private readonly Player[] players;
    private int currentPlayerIndex;
    public ChessGame(Player player1, Player player2)
    {
        board = new Board();
        players = new Player[] { player1, player2 };
        currentPlayerIndex = 0;
    }
    public void StartGame()
    {
        while(!IsGameOver())
        {
            Player currentPlayer = players[currentPlayerIndex];
            Move move = GetMove(board);
            if(board.MovePiece(move))
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            }
        }
        DisplayResult();
    }
    private bool IsGameOver()
    {
        // Simplified game over logic for demonstration purposes
        // In a real implementation, this would involve checking for checkmate, stalemate, etc.
        return board.CheckMate(players[currentPlayerIndex].Color) != 0;
    }
    private void DisplayResult()
    {
        int result = board.CheckMate(players[currentPlayerIndex].Color);
        if(result == 1)
        {
            Console.WriteLine("White wins!");
        }
        else if(result == 2)
        {
            Console.WriteLine("Black wins!");
        }
        else
        {
            Console.WriteLine("Draw!");
        }
    }
    private Move GetMove(Board board)
    {
        Console.WriteLine("Enter source row : ");
        int sourceX = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter source column : ");
        int sourceY = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter destination row : ");
        int destX = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter destination column : ");
        int destY = int.Parse(Console.ReadLine());
        Piece piece = board.GetPieceAt(sourceX, sourceY);
        if (piece == null || piece.Color != players[currentPlayerIndex].Color)
        {
            Console.WriteLine("Invalid piece selection. Try again.");
            return GetMove(board);
        }
        return new Move(piece, destX, destY);
    }
}