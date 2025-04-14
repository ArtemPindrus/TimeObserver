using CommunityToolkit.Mvvm.Input;
using System.Windows;
using TimeObserver.Utilities;
using TimeObserver.Windows;

namespace TimeObserver.ViewModels {
    public partial class SettingsWindowViewModel : ViewModel {
        public SettingsWindowViewModel() {
        }

        [RelayCommand]
        private static void Close() {
            App.HideSettingsWindow();

            WindowsHelper.CloseAllWindows<AddReminderWindow>();
        }
    }
}
