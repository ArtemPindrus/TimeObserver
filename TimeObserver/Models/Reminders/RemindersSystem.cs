using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace TimeObserver.Models.Reminders {
    public class RemindersSystem {
        private const string RemindersFileName = "reminders.json";

        public readonly ReadOnlyObservableCollection<Reminder> Reminders;
        private readonly ObservableCollection<Reminder> reminders = [];

        private CancellationTokenSource serializationTokenSource = new();


        public RemindersSystem() {
            Reminders = new(reminders);
        }

        public void UpdateReminders(TimeSpan elapsedTime) {
            foreach (var reminder in reminders) {
                reminder.Update(elapsedTime);
            }
        }

        public void ResetReminders() {
            foreach (var reminder in reminders) {
                reminder.Reset();
            }
        }

        public void Clear() => reminders.Clear();

        public void AddReminder(Reminder reminder) {
            if (reminders.Any(x => x.IsEqualTo(reminder))) return;

            reminders.Add(reminder);
        }

        public void RemoveReminder(Reminder reminder) => reminders.Remove(reminder);

        public async Task Serialize() {
            serializationTokenSource.Cancel();
            serializationTokenSource = new CancellationTokenSource();

            using FileStream stream = File.Open(RemindersFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            await JsonSerializer.SerializeAsync(stream, reminders, JsonSerializerOptions.Default, serializationTokenSource.Token);
        }

        public async Task TryDeserialize() {
            if (!File.Exists(RemindersFileName)) return;

            using FileStream stream = File.Open(RemindersFileName, FileMode.Open, FileAccess.Read, FileShare.None);

            object? result = 
                await JsonSerializer.DeserializeAsync<ObservableCollection<Reminder>>(stream, JsonSerializerOptions.Default);

            if (result is ObservableCollection<Reminder> deserReminders) {
                reminders.Clear();

                foreach (var item in deserReminders) {
                    reminders.Add(item);
                }
            }
        }
    }
}
