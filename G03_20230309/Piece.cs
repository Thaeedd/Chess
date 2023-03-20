namespace G03_20230309;

abstract class Piece : ICloneable
{
    public Color Color { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public Piece(Color color, int x, int y)
    {
        Color = color;
        X = x;
        Y = y;
    }
    public abstract bool IsValidMove(int moveX, int moveY, Piece[,] board);
    public virtual object Clone()
    {
        return this.MemberwiseClone();
    }
}

enum Color
{
    White = 0,
    Black = 1,
    None = 2
}