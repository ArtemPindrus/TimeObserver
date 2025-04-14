using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TimeObserver.Models.Reminders;
using TimeObserver.Utilities;
using TimeObserver.ViewModels.AddReminderViewModels;
using TimeObserver.Windows;

namespace TimeObserver.ViewModels
{
    public partial class RemindersViewModel : ViewModel {
        public ReadOnlyObservableCollection<Reminder> Reminders => App.RemindersSystem.Reminders;

        public RemindersViewModel() {
        }

        [RelayCommand]
        public static void OpenAddReminderWindow(AddReminderViewModel addReminderViewModel) {
            var mainContent = ViewFinder.FindView(addReminderViewModel);

            if (mainContent == null) return;

            WindowsHelper.OpenWindowIfNotOpen(out AddReminderWindow window);

            var vm = new AddReminderWindowViewModel(mainContent, window);

            window.DataContext = vm;
        }

        [RelayCommand]
        public static void DeleteReminder(Reminder reminder) => App.RemindersSystem.RemoveReminder(reminder);

        [RelayCommand]
        public static async Task Serialize() => await App.RemindersSystem.SerializeAsync();

        [RelayCommand]
        public static async Task Deserialize() => await App.RemindersSystem.TryDeserializeAsync();

        [RelayCommand]
        public static void Clear() => App.RemindersSystem.Clear();
    }
}
