using CommunityToolkit.Mvvm.Input;
using System.Windows;
using TimeObserver.Windows;

namespace TimeObserver.ViewModels {
    public partial class SettingsWindowViewModel : ViewModel {
        private readonly SettingsWindow window;

        public SettingsWindowViewModel(SettingsWindow settingsWindow) {
            window = settingsWindow;
        }

        [RelayCommand]
        private void Close() => window.Hide();
    }
}
