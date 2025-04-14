using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using TimeObserver.ViewModels.AddReminderViewModels;

namespace TimeObserver.Models.Reminders
{
    [AddReminderViewModel(typeof(AddOneTimeReminderViewModel))]
    public partial class OneTimeReminder : Reminder {
        [ObservableProperty]
        private TimeSpan time;

        public OneTimeReminder() : this(TimeSpan.Zero) { }

        public OneTimeReminder(TimeSpan time) {
            this.time = time;
        }

        public override bool CheckTrigger(TimeSpan currentTime) {
            return currentTime == Time;
        }

        public override bool IsEqualTo(Reminder reminder) {
            return reminder is OneTimeReminder oneTimeReminder && Time == oneTimeReminder.Time;
        }

        public override void Remind() {
            MessageBox.Show($"One-time reminder triggered at {Time}!");
        }

        public override void Reset() {
            
        }
    }
}
