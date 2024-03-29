namespace WpfApplicationChess.Models
{
    public class Bishop : ChessPiece
    {
        public Bishop(string color, int x, int y) : base(color, x, y)
        {
        }

        public override bool CanMove(int newX, int newY)
        {
            return Math.Abs(newX - X) == Math.Abs(newY - Y);
        }
    }
}