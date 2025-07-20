using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeObserver.Controls
{
    /// <summary>
    /// Interaction logic for ReminderItem.xaml
    /// </summary>
    public partial class ReminderItem : UserControl {
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register(
                nameof(MainContent),
                typeof(object),
                typeof(ReminderItem),
                new PropertyMetadata(null));

        public object MainContent {
            get => GetValue(MainContentProperty);
            set => SetValue(MainContentProperty, value);
        }

        public ReminderItem() {
            InitializeComponent();
        }
    }
}
