using System.Windows.Controls;

namespace TimeObserver.ViewModels {
    public partial class AddReminderWindowViewModel : ViewModel {
        private readonly ContentControl mainContent;

        public ContentControl MainContent => mainContent;

        public AddReminderWindowViewModel(ContentControl mainContent) {
            this.mainContent = mainContent;
        }
    }
}
