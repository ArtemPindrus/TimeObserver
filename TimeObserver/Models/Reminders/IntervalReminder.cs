using System.Windows;

namespace TimeObserver.Models.Reminders
{
    public class IntervalReminder : Reminder {
        private double secondsInterval;

        public TimeSpan Interval {
            get => TimeSpan.FromSeconds(secondsInterval);
            set {
                secondsInterval = value.TotalSeconds;
                Reset();

                OnPropertyChanged();
            }
        }

        public IntervalReminder() {
            secondsInterval = 0;
        }

        public IntervalReminder(TimeSpan interval) {
            secondsInterval = interval.TotalSeconds;
        }

        public IntervalReminder(TimeSpan interval, TimeSpan elapsedTime) {
            secondsInterval = interval.TotalSeconds;

            TimesTriggered = (int)(elapsedTime.TotalSeconds / secondsInterval);
        }

        public override void Reset() {
            TimesTriggered = (int)(App.Stopwatch.ElapsedTime.TotalSeconds / secondsInterval);
        }

        public override bool CheckTrigger(TimeSpan currentTime) {
            int times = (int)(currentTime.TotalSeconds / secondsInterval);

            return times > TimesTriggered;
        }

        public override void Remind() {
            // TODO: implement
            MessageBox.Show($"Interval Reminder triggered! {TimesTriggered} times.");
        }

        public override bool IsEqualTo(Reminder reminder) {
            if (reminder is not IntervalReminder other) return false;

            return other.Interval == Interval;
        }
    }
}
