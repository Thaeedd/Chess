namespace G03_20230309;

internal class King : Piece
{
    public King(Color color, int x, int y) : base(color, x, y)
    {

    }

    public override bool IsValidMove(int moveX, int moveY, Piece[,] board)
    {
        if ((Math.Abs(moveX - X) == 1 || Math.Abs(moveY - Y) == 1) && (moveX == X || moveY == Y || Math.Abs(moveX - X) == Math.Abs(moveY - Y)))
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        if (Color == Color.Black)
        {
            return "\u001b[31mKn\u001b[0m";
        }
        else
        {
            return "Kn";
        }
    }
}
