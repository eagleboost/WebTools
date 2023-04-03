namespace WebTools.Services;

using WebTools.Utils;

/// <summary>
/// AppLocalStorageService
/// </summary>
public sealed class AppWebDavStorageService : AppStorageServiceBase
{
  protected override Task SaveItemAsyncImpl<T>(string id, T item)
  {
    return Task.CompletedTask;
  }

  protected override Task<T?> LoadItemAsyncImpl<T>(string id) where T : class
  {
    return TaskEx<T>.Empty;
  }
}