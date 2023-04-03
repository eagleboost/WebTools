namespace WebTools.Services;

using Blazored.LocalStorage;

/// <summary>
/// AppLocalStorageService
/// </summary>
public sealed class AppLocalStorageService : AppStorageServiceBase
{
  private readonly ILocalStorageService _service;
  
  public AppLocalStorageService(ILocalStorageService service)
  {
    _service = service;
  }
  
  protected override async Task SaveItemAsyncImpl<T>(string id, T item) where T : class
  {
    await _service.SetItemAsync(id, item);
  }

  protected override async Task<T?> LoadItemAsyncImpl<T>(string id) where T : class
  {
     return await _service.GetItemAsync<T>(id);
  }
}