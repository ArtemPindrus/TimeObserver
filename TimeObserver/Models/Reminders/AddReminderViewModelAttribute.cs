namespace TimeObserver.Models.Reminders {
    /// <summary>
    /// Indicates which ViewModel to use for the AddReminderWindow for this Reminder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AddReminderViewModelAttribute : Attribute {
        public Type AddReminderViewModelType { get; }

        public AddReminderViewModelAttribute(Type addReminderViewModelType) {
            AddReminderViewModelType = addReminderViewModelType;
        }
    }
}
