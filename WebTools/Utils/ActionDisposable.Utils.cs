namespace WebTools.Utils;

/// <summary>
/// ActionDisposableUtils
/// </summary>
public static class ActionDisposableUtils
{
  public static IDisposable CreateCleanup(Action action)
  {
    return new ActionDisposable(action);
  }
}