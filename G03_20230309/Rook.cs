namespace G03_20230309;

internal class Rook : Piece
{
    public Rook(Color color, int x, int y) : base(color, x, y)
    {

    }

    public override bool IsValidMove(int moveX, int moveY, Piece[,] board)
    {
        if((moveX == X || moveY == Y) && !IsPathBLocked(moveX, moveY, board))
        {
            return true;
        }

        return false;
    }

    private bool IsPathBLocked(int moveX, int moveY, Piece[,] board)
    {
        int dirX, dirY;
        int count = 0;

        dirX = (moveX > X) ? -1 : 1;
        dirY = (moveY > Y) ? -1 : 1;

        while (moveX != X || moveY != Y)
        {
            if (count >= 1 || board[moveX, moveY].Color == Color && board[moveX, moveY].ToString() != "_")
            {
                return true;
            }

            if (moveY == Y)
            {
                moveX += dirX;
            }
            else if (moveX == X)
            {
                moveY += dirY;
            }

            if (moveX >= 8 && moveY >= 8 && moveX < 0 && moveY < 0)
            {
                return false;
            }

            if (board[moveX, moveY].ToString() != "_" && board[moveX, moveY].Color != Color)
            {
                count++;
            }
        }

        return false;
    }

    public override string ToString()
    {
        if (Color == Color.Black)
        {
            return "\u001b[31mR\u001b[0m";
        }
        else
        {
            return "R";
        }
    }
}
