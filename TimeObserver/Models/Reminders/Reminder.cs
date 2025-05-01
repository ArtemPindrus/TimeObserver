using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace TimeObserver.Models.Reminders
{
    [JsonDerivedType(typeof(IntervalReminder), "IntervalReminder")]
    [JsonDerivedType(typeof(OneTimeReminder), "OneTimeReminder")]
    public abstract partial class Reminder : ObservableObject {
        [ObservableProperty]
        private bool enabled;

        /// <summary>
        /// Check if Reminder is triggered.
        /// </summary>
        /// <param name="currentTime">Current elapsed time.</param>
        /// <returns>Whether Reminder triggered.</returns>
        public abstract bool CheckTrigger(TimeSpan currentTime);

        public abstract void Remind();

        public abstract void Reset();

        public abstract bool IsEqualTo(Reminder reminder);

        public bool Update(TimeSpan elapsedTime) {
            if (CheckTrigger(elapsedTime)) {
                TimesTriggered++;
                Remind();

                return true;
            }

            return false;
        }

        partial void OnEnabledChanged(bool value) {
            if (value) OnEnabled();
        }

        protected virtual void OnEnabled() { }
    }
}
