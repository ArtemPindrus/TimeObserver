using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeObserver.Utilities
{
    public static class WindowsHelper {
        /// <summary>
        /// Opens a window if it is not already open.
        /// </summary>
        /// <typeparam name="T">Concrete Type of a Window.</typeparam>
        /// <param name="window">Opened or found window.</param>
        /// <returns>Whether a window was opened by function, where false means that window was open prior to function.</returns>
        public static bool OpenWindowIfNotOpen<T>(out T window) where T : Window, new() {
            foreach (Window openWindow in Application.Current.Windows) {
                if (openWindow is T) {
                    window = (T)openWindow;
                    window.Show();
                    return false;
                }
            }

            T newWindow = new();
            newWindow.Show();
            window = newWindow;
            return true;
        }

        public static void CloseAllWindows<T>() where T : Window {
            foreach (Window openWindow in Application.Current.Windows) {
                if (openWindow is T) {
                    openWindow.Close();
                }
            }
        }
    }
}
