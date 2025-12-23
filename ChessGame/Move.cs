public class Move
{
    public Piece Piece { get; }
    public int destinationX { get; }
    public int destinationY { get; }

    public Move(Piece piece, int destinationX, int destinationY)
    {
        Piece = piece;
        this.destinationX = destinationX;
        this.destinationY = destinationY;
    }
    public bool IsValid()
    {
        return Piece.IsValidMove(destinationX, destinationY);
    }
}