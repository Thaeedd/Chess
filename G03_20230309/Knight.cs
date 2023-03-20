namespace G03_20230309;

internal class Knight : Piece
{
    public Knight(Color color, int x, int y) : base(color, x, y)
    {
        
    }

    public override bool IsValidMove(int moveX, int moveY, Piece[,] board)
    {
        if (Math.Abs(moveX - X) == 2 && Math.Abs(moveY - Y) == 1 ||
            Math.Abs(moveY - Y) == 2 && Math.Abs(moveX - X) == 1)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        if (Color == Color.Black)
        {
            return "\u001b[31mK\u001b[0m";
        }
        else
        {
            return "K";
        }
    }
}
