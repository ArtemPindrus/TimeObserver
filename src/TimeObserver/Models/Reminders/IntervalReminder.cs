using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using TimeObserver.ViewModels.AddReminderViewModels;

namespace TimeObserver.Models.Reminders
{
    public partial class IntervalReminder : Reminder {
        private double secondsInterval;

        [ObservableProperty]
        private TimeSpan nextTriggerTime;

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

            UpdateNextTimeTrigger(elapsedTime);
        }

        public override void Reset() {
            UpdateNextTimeTrigger(App.Stopwatch.ElapsedTime);
        }

        protected override void OnEnabled() {
            Reset();
        }

        public override bool CheckTrigger(TimeSpan currentTime) {
            return currentTime.TotalSeconds >= NextTriggerTime.TotalSeconds;
        }

        public override void Remind() {
            // TODO: implement
            MessageBox.Show($"{App.Stopwatch.ElapsedTime} passed!");

            UpdateNextTimeTrigger(App.Stopwatch.ElapsedTime);
        }

        public override bool IsEqualTo(Reminder reminder) {
            if (reminder is not IntervalReminder other) return false;

            return other.Interval == Interval;
        }

        private void UpdateNextTimeTrigger(TimeSpan passedTime) {
            int times = (int)(passedTime.TotalSeconds / secondsInterval);

            NextTriggerTime = TimeSpan.FromSeconds(secondsInterval * (times + 1));
        }
    }
}
