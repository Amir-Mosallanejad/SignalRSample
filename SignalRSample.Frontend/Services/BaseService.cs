using Blazored.LocalStorage;

namespace SignalRSample.Frontend.Services;

public abstract class BaseService(IHttpClientFactory _HttpClientFactorylient, ILocalStorageService _localStorageService)
{
    protected HttpClient myApiClient = _HttpClientFactorylient.CreateClient("MyApi");
    
}