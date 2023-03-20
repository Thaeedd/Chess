namespace G03_20230309;

internal class ChessGame
{
    public Piece[,] board = new Piece[8, 8];
    public ChessGame()
    {
        StartingBoard();
    }

    public void Move(Piece piece, int moveX, int moveY, Color color, Piece[,] board)
    {
        if (IsKingInCheck(Color.Black, board))
        {
            if (piece is King && !CanKingEscapeCheck(moveX, moveY, board, Color.White))
            {
                return;
            }
            else if (piece is not King && !CanPieceBlockCheck(piece, moveX, moveY, Color.White))
            {
                return;
            }
        }

        if (piece.IsValidMove(moveX, moveY, board) && piece.Color != board[moveX, moveY]?.Color)
        {
            if (IsMoveRevealingCheck(piece, moveX, moveY, Color.Black))
            {
                return;
            }

            board[moveX, moveY] = piece;
            board[piece.X, piece.Y] = new EmptyPiece(Color.None, piece.X, piece.Y);
            piece.X = moveX;
            piece.Y = moveY;
        }
        if (IsCheckmate(Color.Black, board))
        {
            Console.WriteLine("Checkmate");
            return;
        }
    }

    private bool IsCheckmate(Color color, Piece[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!IsKingInCheck(Color.Black, board) && (CanKingEscapeCheck(i, j, board, Color.Black) || CanPieceBlockCheck(board[i, j], i, j, Color.Black)))
                {
                    return false;
                }
            }
        }

        return true;
    }
    private bool IsMoveRevealingCheck(Piece piece, int x, int y, Color color)
    {
        Piece[,] tempBoard = new Piece[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] != null)
                {
                    tempBoard[i, j] = (Piece)board[i, j].Clone();
                }
            }
        }

        tempBoard[x, y] = piece;
        tempBoard[piece.X, piece.Y] = new EmptyPiece(Color.None, piece.X, piece.Y);
        if (piece is not King && IsKingInCheck(color, tempBoard))
        {
            return true;
        }

        return false;
    }

    private bool CanPieceBlockCheck(Piece piece, int x, int y, Color color)
    {
        Piece[,] tempBoard = new Piece[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] != null)
                {
                    tempBoard[i, j] = (Piece)board[i, j].Clone();
                }
            }
        }

        tempBoard[piece.X, piece.Y] = new EmptyPiece(Color.None, piece.X, piece.Y);

        if (piece.IsValidMove(x, y, board))
        {
            tempBoard[x, y] = piece;
        }
        else
        {
            return false;
        }

        if (IsKingInCheck(color, tempBoard))
        {
            return false;
        }

        return true;
    }

    private bool IsKingInCheck(Color color, Piece[,] board)
    {
        King? king = null;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] is King && board[i, j].Color == color)
                {
                    king = (King)board[i, j];
                    break;
                }
            }
            if (king != null)
            {
                break;
            }
        }

        foreach (Piece piece in board)
        {
            if (piece is not King && piece is not EmptyPiece && piece.Color != king.Color && piece.IsValidMove(king.X, king.Y, board))
            {
                return true;
            }
        }

        return false;
    }

    private bool CanKingEscapeCheck(int x, int y, Piece[,] board, Color color)
    {
        King king = new King(color, -1, -1);
        Piece[,] tempBoard = new Piece[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] != null)
                {
                    tempBoard[i, j] = (Piece)board[i, j].Clone();
                }
            }
        }

        if (king.IsValidMove(x, y, board))
        {
            tempBoard[x, y] = king;
        }
        else
        {
            return false;
        }

        foreach (Piece piece in tempBoard)
        {
            if (piece is not King && piece is not EmptyPiece && piece.Color != king.Color && piece.IsValidMove(x, y, tempBoard))
            {
                return false;
            }
        }

        return true;
    }

    private void StartingBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = new EmptyPiece(Color.None, i, j);
            }
        }
        //board[0, 4] = new King(Color.Black, 0, 4);
        //board[2, 7] = new Rook(Color.White, 2, 7);
        //board[1, 0] = new Rook(Color.White, 1, 0);



        board[0, 0] = new Rook(Color.Black, 0, 0);
        board[0, 1] = new Knight(Color.Black, 0, 1);
        board[0, 2] = new Bishop(Color.Black, 0, 2);
        board[0, 3] = new Queen(Color.Black, 0, 3);
        board[0, 4] = new King(Color.Black, 0, 4);
        board[0, 5] = new Bishop(Color.Black, 0, 5);
        board[0, 6] = new Knight(Color.Black, 0, 6);
        board[0, 7] = new Rook(Color.Black, 0, 7);

        for (int i = 0; i < board.GetLength(0); i++)
        {
            board[1, i] = new Pawn(Color.Black, 1, i);
        }

        for (int i = 0; i < board.GetLength(0); i++)
        {
            board[6, i] = new Pawn(Color.White, 6, i);
        }

        board[7, 0] = new Rook(Color.White, 7, 0);
        board[7, 1] = new Knight(Color.White, 7, 1);
        board[7, 2] = new Bishop(Color.White, 7, 2);
        board[7, 3] = new Queen(Color.White, 7, 3);
        board[7, 4] = new King(Color.White, 7, 4);
        board[7, 5] = new Bishop(Color.White, 7, 5);
        board[7, 6] = new Knight(Color.White, 7, 6);
        board[7, 7] = new Rook(Color.White, 7, 7);
    }
}

