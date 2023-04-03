namespace WebTools.Utils;

public static class RefUtils
{
  public static void DisposeEx<T>(ref T? disposable) where T : class, IDisposable
  {
    var d = Interlocked.Exchange(ref disposable, null);
    d?.Dispose();
  }
  
  public static void DisposeReset<T>(ref T? disposable, T newValue) where T : class, IDisposable
  {
    var d = Interlocked.Exchange(ref disposable, newValue);
    d?.Dispose();
  }
}