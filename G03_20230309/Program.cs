using G03_20230309;

ChessGame? chessGame = new ChessGame();
Piece?[,] board = chessGame.board;


















































for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        Console.Write($" {chessGame.board[i, j]} ");
    }
    Console.WriteLine();
}
