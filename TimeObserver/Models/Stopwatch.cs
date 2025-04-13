using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeObserver.Models;

public partial class Stopwatch : ObservableObject {
    private readonly TimeSpan oneSecond = TimeSpan.FromSeconds(1);
    private readonly DispatcherTimer timer;
    
    private TimeSpan elapsedTime;

    [ObservableProperty]
    private bool isRunning;

    public TimeSpan ElapsedTime {
        get => elapsedTime;
        private set => SetProperty(ref elapsedTime, value);
    }

    public Stopwatch() {
        timer = new() {
            Interval = oneSecond,
        };
        
        timer.Tick += TimerOnTick;
    }

    public void Resume() {
        timer.Start();
        IsRunning = true;
    }

    public void Pause() { 
        timer.Stop(); 
        IsRunning = false;
    }

    /// <summary>
    /// Stops the stopwatch and resets elapsed time.
    /// </summary>
    public void Stop() {
        timer.Stop();
        ElapsedTime = TimeSpan.Zero;
        IsRunning = false;
    }

    private void TimerOnTick(object? sender, EventArgs e) {
        ElapsedTime += oneSecond;
    }
}