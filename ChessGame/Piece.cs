// Represents a chess square box in chess board
public abstract class Piece
{
    public Color Color { get; private set; }
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }

    public Piece(Color color, int positionX, int positionY)
    {
        Color = color;
        PositionX = positionX;
        PositionY = positionY;
    }
    public void SetPosition(int x, int y)
    {
        PositionX = x;
        PositionY = y;
    }
    public abstract bool IsValidMove(int newX, int newY);
}

// King, Queen, Rook, Bishop, Knight, Pawn classes would inherit from Piece and implement IsValidMove accordingly.
public class King : Piece
{
    public King(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        int deltaX = Math.Abs(newX - PositionX);
        int deltaY = Math.Abs(newY - PositionY);
        return deltaX <= 1 && deltaY <= 1;
    }
}

public class Queen : Piece
{
    public Queen(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        int deltaX = Math.Abs(newX - PositionX);
        int deltaY = Math.Abs(newY - PositionY);
        return deltaX == deltaY || newX == PositionX || newY == PositionY;
    }
}

public class Rook : Piece
{
    public Rook(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        return newX == PositionX || newY == PositionY;
    }
}
public class Bishop : Piece
{
    public Bishop(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        int deltaX = Math.Abs(newX - PositionX);
        int deltaY = Math.Abs(newY - PositionY);
        return deltaX == deltaY;
    }
}

public class Knight : Piece
{
    public Knight(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        int deltaX = Math.Abs(newX - PositionX);
        int deltaY = Math.Abs(newY - PositionY);
        return (deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2);
    }
}
public class Pawn : Piece
{
    public Pawn(Color color, int positionX, int positionY) : base(color, positionX, positionY) { }

    public override bool IsValidMove(int newX, int newY)
    {
        int direction = (Color == Color.White) ? 1 : -1;
        if (newX == PositionX && newY == PositionY + direction)
        {
            return true;
        }
        // Initial double move
        if ((Color == Color.White && PositionY == 1) || (Color == Color.Black && PositionY == 6))
        {
            if (newX == PositionX && newY == PositionY + 2 * direction)
            {
                return true;
            }
        }
        return false;
    }
}

