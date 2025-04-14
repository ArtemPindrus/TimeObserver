using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeObserver.Models.Reminders;

namespace TimeObserver.ViewModels.AddReminderViewModels {
    public partial class AddOneTimeReminderViewModel : AddReminderViewModel {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCommand))]
        private string? time;

        private TimeSpan lastParsedTime;

        protected override bool CanConstruct() {
            return TimeSpan.TryParse(Time, out lastParsedTime);
        }

        protected override Reminder ConstructReminder() => new OneTimeReminder(lastParsedTime);
    }
}
