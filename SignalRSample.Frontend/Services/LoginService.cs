using System.Net.Http.Json;
using Blazored.LocalStorage;
using SignalRSample.Frontend.Dtos;

namespace SignalRSample.Frontend.Services;

public class LoginService(IHttpClientFactory _HttpClientFactorylient, ILocalStorageService _localStorageService) : BaseService(_HttpClientFactorylient, _localStorageService)
{
    public async Task Login(AuthenticateDto dto)
    {
        var a = await myApiClient.PostAsJsonAsync("Authentication/token", dto);
        var token = await a.Content.ReadAsStringAsync();
        await _localStorageService.SetItemAsync("token", token);
    }
}