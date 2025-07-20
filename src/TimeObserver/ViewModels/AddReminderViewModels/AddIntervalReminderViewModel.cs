using CommunityToolkit.Mvvm.ComponentModel;
using TimeObserver.Models.Reminders;

namespace TimeObserver.ViewModels.AddReminderViewModels {
    public partial class AddIntervalReminderViewModel : AddReminderViewModel {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCommand))]
        private string? intervalStr;

        private TimeSpan lastParsed;

        protected override bool CanConstruct() {
            return TimeSpan.TryParse(IntervalStr, out lastParsed);
        }

        protected override Reminder ConstructReminder() => new IntervalReminder(lastParsed, App.Stopwatch.ElapsedTime);
    }
}
