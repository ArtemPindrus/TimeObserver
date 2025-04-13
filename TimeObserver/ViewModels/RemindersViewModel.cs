using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TimeObserver.Models.Reminders;

namespace TimeObserver.ViewModels
{
    public partial class RemindersViewModel : ViewModel {
        public ReadOnlyObservableCollection<Reminder> Reminders => App.RemindersSystem.Reminders;

        public RemindersViewModel() {
        }

        [RelayCommand]
        public static void DeleteReminder(Reminder reminder) => App.RemindersSystem.RemoveReminder(reminder);

        [RelayCommand]
        public static async Task Serialize() => await App.RemindersSystem.Serialize();

        [RelayCommand]
        public static async Task Deserialize() => await App.RemindersSystem.TryDeserialize();

        [RelayCommand]
        public static void Clear() => App.RemindersSystem.Clear();
    }
}
