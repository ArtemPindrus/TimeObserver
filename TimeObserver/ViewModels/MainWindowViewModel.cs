using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TimeObserver.ViewModels;

public partial class MainWindowViewModel : ViewModel {
    private readonly App app;

    [ObservableProperty]
    private Visibility windowVisibility;

    public MainWindowViewModel() {
        app = (App)Application.Current;
    }

    [RelayCommand]
    private static void CloseApplication() {
        Application.Current.Shutdown();
    }

    [RelayCommand]
    private void ShowSettingsWindow() {
        App.ShowSettingsWindow();
    }

    [RelayCommand]
    private void ToTray() {
        WindowVisibility = Visibility.Hidden;
    }

    [RelayCommand]
    private void ShowWindow() {
        WindowVisibility = Visibility.Visible;
    }
}