namespace WebTools.Services;

using WebTools.Utils;

/// <summary>
/// AppStorageServiceBase
/// </summary>
public abstract class AppStorageServiceBase : IAppStorageService
{
  #region IAppStorageService
  public Task SaveItemAsync<T>(string id, T item) where T : class
  {
    if (id == null || item == null)
    {
      return Task.CompletedTask;
    }

    return SaveItemAsyncCore(id, item);
  }

  public Task<T?> LoadItemAsync<T>(string id) where T : class
  {
    return id == null ? TaskEx<T>.Empty : LoadItemAsyncCore<T>(id);
  }
  #endregion IAppStorageService

  #region Virtuals
  protected abstract Task SaveItemAsyncImpl<T>(string id, T item) where T : class;

  protected abstract Task<T?> LoadItemAsyncImpl<T>(string id) where T : class;
  #endregion Virtuals

  #region Private Methods
  private Task SaveItemAsyncCore<T>(string id, T item) where T : class
  {
    return SaveItemAsyncImpl(id, item);
  }
  
  private Task<T?> LoadItemAsyncCore<T>(string id) where T : class
  {
    return LoadItemAsyncImpl<T>(id);
  }
  #endregion Private Methods
}