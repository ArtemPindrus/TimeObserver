using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using TimeObserver.Extensions;
using TimeObserver.Models.Reminders;
using TimeObserver.ViewModels;

namespace TimeObserver.Views
{
    /// <summary>
    /// Interaction logic for RemindersView.xaml
    /// </summary>
    public partial class RemindersView : UserControl
    {
        public RemindersView() {
            InitializeComponent();
            DataContext = new RemindersViewModel();

            FillInAddButtonContextMenu();
        }

        private void FillInAddButtonContextMenu() {
            Type reminderBaseType = typeof(Reminder);
            IEnumerable<Type> types = reminderBaseType.Assembly.GetTypes().Where(x => x.IsSubclassOf(reminderBaseType) && x != reminderBaseType);
            ICommand openAddReminderWindowCommand = ((RemindersViewModel)DataContext).OpenAddReminderWindowCommand;

            foreach (var subType in types) {
                var addReminderViewModelAttribute = subType.GetCustomAttribute<AddReminderViewModelAttribute>();
                if (addReminderViewModelAttribute == null) 
                    throw new Exception($"Reminder Type {subType.Name} isn't decorated with {nameof(AddReminderViewModelAttribute)}");

                var menuItem = new MenuItem() {
                    Header = subType.Name.SeparateByUppercase(),
                    Command = openAddReminderWindowCommand,
                    CommandParameter = Activator.CreateInstance(addReminderViewModelAttribute.AddReminderViewModelType),
                };

                AddButtonContextMenu.Items.Add(menuItem);
            }
        }
    }
}
