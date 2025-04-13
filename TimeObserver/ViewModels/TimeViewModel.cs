using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using TimeObserver.Models;

namespace TimeObserver.ViewModels;

public partial class TimeViewModel : ViewModel {
    private readonly Stopwatch stopwatch;

    public bool StopwatchIsRunning => stopwatch.IsRunning;

    public string ElapsedTime => stopwatch.ElapsedTime.ToString();

    public TimeViewModel() {
        stopwatch = App.Stopwatch;
        stopwatch.PropertyChanged += StopwatchOnPropertyChanged;
    }

    [RelayCommand]
    private void Resume() => stopwatch.Resume();

    [RelayCommand]
    private void Stop() => stopwatch.Stop();

    [RelayCommand]
    private void Pause() => stopwatch.Pause();

    private void StopwatchOnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(Stopwatch.ElapsedTime)) {
            OnPropertyChanged(e);
        } else if (e.PropertyName == nameof(Stopwatch.IsRunning)) {
            OnPropertyChanged(nameof(StopwatchIsRunning));
        }
    }
}