namespace WebTools.Utils;

using System.Timers;
using Timer = System.Timers.Timer;
using static RefUtils;

/// <summary>
/// PeriodicExecutor
/// </summary>
public sealed class PeriodicExecutor : IPeriodicExecutor, IDisposable
{
  private Timer? _timer;

  public PeriodicExecutor()
  {
    var timer = new Timer(10_000);
    timer.Elapsed += HandleTimerElapsed;
    _timer = timer;
  }
  
  public event EventHandler? Execute;

  public void Start()
  {
    if (_timer != null)
    {
      _timer.Enabled = true;
    }
  }
  
  private void HandleTimerElapsed(object? sender, ElapsedEventArgs e)
  {
    Execute?.Invoke(this, EventArgs.Empty);
  }

  public void Dispose()
  {
    DisposeEx(ref _timer);
  }
}