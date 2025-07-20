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
        }
    }
}
