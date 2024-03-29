using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApplicationChess.Models;

namespace WpfApplicationChess.ViewModels
{
    public class ChessViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _figureTypes;
        private ObservableCollection<string> _colors;
        private string _selectedFigureType;
        private string _selectedColor;
        private int _initialX;
        private int _initialY;
        private int _finalX;
        private int _finalY;
        private string _resultMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> FigureTypes
        {
            get { return _figureTypes; }
            set
            {
                _figureTypes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnPropertyChanged();
            }
        }

        public string SelectedFigureType
        {
            get { return _selectedFigureType; }
            set
            {
                _selectedFigureType = value;
                OnPropertyChanged();
            }
        }

        public string SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        public int InitialX
        {
            get { return _initialX; }
            set
            {
                _initialX = value;
                OnPropertyChanged();
            }
        }

        public int InitialY
        {
            get { return _initialY; }
            set
            {
                _initialY = value;
                OnPropertyChanged();
            }
        }

        public int FinalX
        {
            get { return _finalX; }
            set
            {
                _finalX = value;
                OnPropertyChanged();
            }
        }

        public int FinalY
        {
            get { return _finalY; }
            set
            {
                _finalY = value;
                OnPropertyChanged();
            }
        }

        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                _resultMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand MoveCommand { get; }

        public ChessViewModel()
        {
            FigureTypes = new ObservableCollection<string>() { "Queen", "Rook", "Bishop" };
            Colors = new ObservableCollection<string>() { "White", "Black" };
            MoveCommand = new RelayCommand(Move);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Move(object parameter)
        {
            if (string.IsNullOrEmpty(SelectedFigureType) || string.IsNullOrEmpty(SelectedColor))
            {
                ResultMessage = "Выберите фигуру и цвет.";
                return;
            }
            
            ChessPiece piece = null;
            switch (SelectedFigureType)
            {
                case "Queen":
                    piece = new Queen(SelectedColor, InitialX, InitialY);
                    break;
                case "Rook":
                    piece = new Rook(SelectedColor, InitialX, InitialY);
                    break;
                case "Bishop":
                    piece = new Bishop(SelectedColor, InitialX, InitialY);
                    break;
            }
            
            if (piece != null && piece.CanMove(FinalX, FinalY))
            {
                ResultMessage = "Ход выполнен успешно.";
            }
            else
            {
                ResultMessage = "Данная фигура туда не ходит.";
            }
        }
    }
    
}