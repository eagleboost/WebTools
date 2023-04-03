namespace WebTools.Utils;
using static ActionDisposableUtils;

public static class PeriodicExecutorExt
{
  public static IDisposable HookExecute(this IPeriodicExecutor executor, EventHandler handler)
  {
    executor.Execute += handler;
    return CreateCleanup(() => executor.Execute += handler);
  }
}