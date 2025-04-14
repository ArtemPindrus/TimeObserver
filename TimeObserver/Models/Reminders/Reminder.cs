using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace TimeObserver.Models.Reminders
{
    [JsonDerivedType(typeof(IntervalReminder), "IntervalReminder")]
    [JsonDerivedType(typeof(OneTimeReminder), "OneTimeReminder")]
    public abstract class Reminder : ObservableObject {
        [JsonIgnore]
        public int TimesTriggered { get; protected set; }

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
    }
}
