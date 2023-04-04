namespace WebTools.Services;

/// <summary>
/// AppStorageService
/// </summary>
public sealed class AppStorageService : AppStorageServiceBase
{
  private readonly AppWebDavStorageService _webDavService;
  private readonly AppLocalStorageService _localService;

  public AppStorageService(AppWebDavStorageService webDavService, AppLocalStorageService localService)
  {
    _webDavService = webDavService;
    _localService = localService;
  }

  #region Overrides
  protected override async Task SaveItemAsyncImpl<T>(string id, T item)
  {
    try
    {
      await _webDavService.SaveItemAsync(id, item).ConfigureAwait(false);
    }
    catch (Exception)
    {
    }
    finally
    {
      await _localService.SaveItemAsync(id, item).ConfigureAwait(false);
    }
  }

  protected override async Task<T?> LoadItemAsyncImpl<T>(string id) where T : class
  {
    try
    {
      var remoteItem = await LoadRemoteItemAsync<T>(id).ConfigureAwait(false);
      if (remoteItem != null)
      {
        return remoteItem;
      }
      
      return await LoadLocalItemAsync<T>(id).ConfigureAwait(false);
    }
    catch (Exception)
    {
      return await LoadLocalItemAsync<T>(id).ConfigureAwait(false);
    }
  }
  #endregion Overrides

  #region Private Methods
  private async Task<T?> LoadRemoteItemAsync<T>(string id) where T : class
  {
    var result = await _webDavService.LoadItemAsync<T>(id).ConfigureAwait(false);
    return result;
  }
  
  private async Task<T?> LoadLocalItemAsync<T>(string id) where T : class
  {
    var result = await _localService.LoadItemAsync<T>(id).ConfigureAwait(false);
    return result;
  }
  #endregion Private Methods
}