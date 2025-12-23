using System.Runtime.CompilerServices;

public class Board
{
    private Piece[,] squares;

    public Board()
    {
        squares = new Piece[8, 8];
        // Initialize pieces on the board
        intializePieces();
    }
    private void intializePieces()
    {
        // Place Rooks
        squares[0, 0] = new Rook(Color.White, 0, 0);
        squares[7, 0] = new Rook(Color.White, 7, 0);
        squares[0, 7] = new Rook(Color.Black, 0, 7);
        squares[7, 7] = new Rook(Color.Black, 7, 7);
        // Place Knights
        squares[1, 0] = new Knight(Color.White, 1, 0);
        squares[6, 0] = new Knight(Color.White, 6, 0);
        squares[1, 7] = new Knight(Color.Black, 1, 7);
        squares[6, 7] = new Knight(Color.Black, 6, 7);
        // Place Bishops
        squares[2, 0] = new Bishop(Color.White, 2, 0);
        squares[5, 0] = new Bishop(Color.White, 5, 0);
        squares[2, 7] = new Bishop(Color.Black, 2, 7);
        squares[5, 7] = new Bishop(Color.Black, 5, 7);

        // Place Queens
        squares[3, 0] = new Queen(Color.White, 3, 0);
        squares[3, 7] = new Queen(Color.Black, 3, 7);

        // Place Pawns
        for (int i = 0; i < 8; i++)
        {
            squares[i, 1] = new Pawn(Color.White, i, 1);
            squares[i, 6] = new Pawn(Color.Black, i, 6);
        }
        // Kings
        squares[4, 0] = new King(Color.White, 4, 0);
        squares[4, 7] = new King(Color.Black, 4, 7);
    }
    public Piece GetPieceAt(int x, int y)
    {
        return squares[x, y];
    }

    public void SetPieceAt(int x, int y, Piece piece)
    {
        squares[x, y] = piece;
    }
    public bool IsValidMove(Piece piece, int destX, int destY)
    {
        if (piece == null)
            return false;
        if( destX < 0 || destX >= 8 || destY < 0 || destY >= 8)
            return false;
        return piece.IsValidMove(destX, destY);
    }

    public bool MovePiece(Move move)
    {
        if (move.IsValid())
        {
            Piece piece = move.Piece;
            int destX = move.destinationX;
            int destY = move.destinationY;

            squares[piece.PositionX, piece.PositionY] = null;
            piece.SetPosition(destX, destY);
            squares[destX, destY] = piece;
            return true;
        }
        return false;
    }
    public int CheckMate(Color currentPlayer)
    {
        // Simplified checkmate logic for demonstration purposes
        // In a real implementation, this would involve checking all possible moves
        // and determining if the king is in check with no valid moves left.
        return 0; // 0 = No checkmate, 1 = White wins, 2 = Black wins
    }

}