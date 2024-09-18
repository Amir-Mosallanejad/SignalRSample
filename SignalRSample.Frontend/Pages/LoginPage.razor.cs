using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SignalRSample.Frontend.Dtos;

namespace SignalRSample.Frontend.Pages;

public partial class LoginPage
{
    [Inject] private IHttpClientFactory _HttpClientFactorylient { get; set; }
    [Inject] private ILocalStorageService _localStorageService { get; set; }


    private string userName;
    private HttpClient myApiClient;


    protected override Task OnInitializedAsync()
    {
        myApiClient = _HttpClientFactorylient.CreateClient("MyApi");

        return base.OnInitializedAsync();
    }

    private async Task Login()
    {
        AuthenticateDto dto = new()
        {
            Username = userName
        };
        var a = await myApiClient.PostAsJsonAsync("Authentication/token", dto);
        var token = await a.Content.ReadAsStringAsync();
        await _localStorageService.SetItemAsync("token", token);
    }
}