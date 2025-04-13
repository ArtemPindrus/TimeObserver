using System.Windows;
using TimeObserver.Models;
using TimeObserver.ViewModels;
using TimeObserver.Windows;

namespace TimeObserver;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    public readonly Stopwatch Stopwatch = new();
    public SettingsWindow SettingsWindow { get; private set; }
    public static readonly RemindersSystem RemindersSystem = new();
    
    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        SettingsWindow = new();
        SettingsWindow.DataContext = new SettingsWindowViewModel(SettingsWindow);

        Stopwatch.Resume();

        MainWindow mainWindow = new MainWindow() {
            DataContext = new MainWindowViewModel()
        };

        MainWindow = mainWindow;
        mainWindow.Show();

        Stopwatch.Tick += Stopwatch_Tick;
        Stopwatch.Stopped += Stopwatch_Stopped;

    }

    private void Stopwatch_Stopped() {
        RemindersSystem.ResetReminders();
    }

    private void Stopwatch_Tick(TimeSpan elapsedTime) {
        RemindersSystem.UpdateReminders(elapsedTime);
    }
}