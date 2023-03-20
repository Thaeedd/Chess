namespace G03_20230309;

internal class Pawn : Piece
{
    private bool _hasMoved;
    public Pawn(Color color, int x, int y) : base(color, x, y)
    {
        _hasMoved = false;
    }
    public override bool IsValidMove(int moveX, int moveY, Piece[,] board)
    {
        if (!_hasMoved && moveY == Y && (Math.Abs(moveX - X) == 1 || Math.Abs(moveX - X) == 2)
            && board[moveX, moveY].ToString() == "_")
        {
            if(Math.Abs(moveX - X) == 2 && board[(moveX + X) / 2, moveY].ToString() != "_")
            {
                return false;
            }

            _hasMoved = true;

            return true;
        }
        else if (_hasMoved && moveY == Y && Math.Abs(moveX - X) == 1 && board[moveX, moveY].ToString() == "_")
        {
            return true;
        }
        else if(Math.Abs(moveX - X) == 1 && Math.Abs(moveY - Y) == 1 && board[moveX, moveY].ToString() != "_")
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        if (Color == Color.Black)
        {
            return "\u001b[31mP\u001b[0m";
        }
        else
        {
            return "P";
        }
    }
}
