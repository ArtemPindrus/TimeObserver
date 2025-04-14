using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using TimeObserver.ViewModels.AddReminderViewModels;
using TimeObserver.Windows;

namespace TimeObserver.ViewModels {
    public partial class AddReminderWindowViewModel : ViewModel {
        private readonly ContentControl mainContent;
        private readonly AddReminderWindow window;

        public ContentControl MainContent => mainContent;

        public AddReminderWindowViewModel(ContentControl mainContent, AddReminderWindow window) {
            this.mainContent = mainContent;
            this.window = window;
        }

        [RelayCommand]
        private void Close() => window.Close();
    }
}
