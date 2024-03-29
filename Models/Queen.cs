namespace WpfApplicationChess.Models
{
    public class Queen : ChessPiece
    {
        public Queen(string color, int x, int y) : base(color, x, y)
        {
        }

        public override bool CanMove(int newX, int newY)
        {
            int deltaX = Math.Abs(newX - X);
            int deltaY = Math.Abs(newY - Y);
            
            bool isRookMove = newX == X || newY == Y;
            
            bool isBishopMove = deltaX == deltaY;
            
            return isRookMove || isBishopMove;
        }
    }
}