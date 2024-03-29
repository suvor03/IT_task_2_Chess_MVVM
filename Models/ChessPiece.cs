using System.ComponentModel;

namespace WpfApplicationChess.Models
{
    public abstract class ChessPiece : INotifyPropertyChanged
    {
        private string _color;
        private int _x;
        private int _y;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        public ChessPiece(string color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }

        public abstract bool CanMove(int newX, int newY);

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}