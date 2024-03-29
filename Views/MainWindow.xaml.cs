using System.Windows;
using WpfApplicationChess.ViewModels;

namespace WpfApplicationChess.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ChessViewModel();
    }
    
    private void MoveButton_Click(object sender, RoutedEventArgs e)
    {
        (DataContext as WpfApplicationChess.ViewModels.ChessViewModel).Move(null);
    }
}