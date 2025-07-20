using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace TimeObserver.Models.Reminders
{
    public partial class OneshotReminder : Reminder {
        [ObservableProperty]
        private TimeSpan time;

        public OneshotReminder() : this(TimeSpan.Zero) { }

        public OneshotReminder(TimeSpan time) {
            this.time = time;
        }

        public override bool CheckTrigger(TimeSpan currentTime) {
            return currentTime == Time;
        }

        public override bool IsEqualTo(Reminder reminder) {
            return reminder is OneshotReminder oneTimeReminder && Time == oneTimeReminder.Time;
        }

        public override void Remind() {
            MessageBox.Show($"One-time reminder triggered at {Time}!");
        }

        public override void Reset() {
            
        }
    }
}
