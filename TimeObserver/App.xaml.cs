using System.Threading.Tasks;
using System.Windows;
using TimeObserver.Models;
using TimeObserver.Models.Reminders;
using TimeObserver.Utilities;
using TimeObserver.ViewModels;
using TimeObserver.ViewModels.AddReminderViewModels;
using TimeObserver.Windows;
using Microsoft.Win32;

namespace TimeObserver;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    public static readonly Stopwatch Stopwatch = new();
    public static readonly RemindersSystem RemindersSystem = new();

    private static readonly SettingsWindow settingsWindow = new() {
        DataContext = new SettingsWindowViewModel()
    };

    
    protected async override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        Stopwatch.Resume();

        MainWindow mainWindow = new() {
            DataContext = new MainWindowViewModel()
        };

        MainWindow = mainWindow;
        mainWindow.Show();

        Stopwatch.Tick += Stopwatch_Tick;
        Stopwatch.Stopped += Stopwatch_Stopped;
        SystemEvents.SessionSwitch += OnSessionSwitch;

        await RemindersSystem.TryDeserializeAsync();
    }

    private void OnSessionSwitch(object sender, SessionSwitchEventArgs e) {
        if (e.Reason == SessionSwitchReason.SessionUnlock) {
            Stopwatch.Restart();
        }
    }

    protected override async void OnExit(ExitEventArgs e) {
        await RemindersSystem.SerializeAsync();

        base.OnExit(e);
    }

    private void Stopwatch_Stopped() {
        RemindersSystem.ResetReminders();
    }

    private void Stopwatch_Tick(TimeSpan elapsedTime) {
        RemindersSystem.UpdateReminders(elapsedTime);
    }

    public static void ShowSettingsWindow() => settingsWindow.Show();

    public static void HideSettingsWindow() => settingsWindow.Hide();
}