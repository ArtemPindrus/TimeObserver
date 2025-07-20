using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TimeObserver.Models.Reminders;
using TimeObserver.ViewModels.AddReminderViewModels;
using TimeObserver.Views.AddReminder;
using TimeObserver.Windows;

namespace TimeObserver.ViewModels
{
    public partial class RemindersViewModel : ViewModel {
        public ReadOnlyObservableCollection<Reminder> Reminders => App.RemindersSystem.Reminders;

        [RelayCommand]
        public void OpenAddIntervalReminderWindow() {
            var mainContent = new AddIntervalReminderView() {
                DataContext = new AddIntervalReminderViewModel()
            };

            AddReminderWindow addReminderWindow = new() { 
                DataContext = new AddReminderWindowViewModel(mainContent)    
            };

            addReminderWindow.Show();
        }

        [RelayCommand]
        public void OpenAddOneshotReminderWindow() {
            var mainContent = new AddOneshotReminderView() {
                DataContext = new AddOneshotReminderViewModel()
            };

            AddReminderWindow addReminderWindow = new() {
                DataContext = new AddReminderWindowViewModel(mainContent)
            };

            addReminderWindow.Show();
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
