namespace WpfApplicationChess.Models
{
    public class Rook : ChessPiece
    {
        public Rook(string color, int x, int y) : base(color, x, y)
        {
        }

        public override bool CanMove(int newX, int newY)
        {
            return newX == X || newY == Y;
        }
    }
}
