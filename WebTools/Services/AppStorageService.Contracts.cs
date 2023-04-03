namespace WebTools.Services;

/// <summary>
/// IAppStorageService
/// </summary>
public interface IAppStorageService
{
  Task SaveItemAsync<T>(string id, T item) where T : class;
  
  Task<T?> LoadItemAsync<T>(string id) where T : class;
}