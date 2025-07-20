using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeObserver;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        Header.Visibility = Visibility.Hidden;
    }

    private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        DragMove();
    }

    private void MainWindow_OnMouseEnter(object sender, MouseEventArgs e) {
        Header.Visibility = Visibility.Visible;
    }

    private void MainWindow_OnMouseLeave(object sender, MouseEventArgs e) {
        Header.Visibility = Visibility.Hidden;
    }
}