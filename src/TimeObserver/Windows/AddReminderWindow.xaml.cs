using System.Windows;
using System.Windows.Input;

namespace TimeObserver.Windows {
    /// <summary>
    /// Interaction logic for AddReminderWindow.xaml
    /// </summary>
    public partial class AddReminderWindow : Window {
        public AddReminderWindow() {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
