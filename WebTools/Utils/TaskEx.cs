namespace WebTools.Utils;

/// <summary>
/// TaskEx
/// </summary>
/// <typeparam name="T"></typeparam>
public static class TaskEx<T>
{
  public static readonly Task<T?> Empty = Task.FromResult(default(T));
}