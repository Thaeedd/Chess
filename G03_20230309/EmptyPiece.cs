namespace G03_20230309;

internal class EmptyPiece : Piece
{
    public EmptyPiece(Color color, int x, int y) : base(color, x, y)
    {

    }

    public override bool IsValidMove(int moveX, int moveY, Piece[,] board)
    {
        return true;
    }

    public override string ToString()
    {
        return "_";
    }
}