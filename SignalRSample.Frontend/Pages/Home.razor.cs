using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRSample.Frontend.Consts;
using SignalRSample.Frontend.HubServise;

namespace SignalRSample.Frontend.Pages;

partial class Home
{
    // [Inject] private IHttpClientFactory _HttpClientFactorylient { get; set; }
    //
    // [Inject] private ILocalStorageService _localStorage { get; set; }
    // [Inject] private ChatHubServices HubServices { get; set; }
    //
    // private List<string> _messages = [];
    // private HubConnection _hubConnection;
    // private string messageInput;
    // private HttpClient myApiClient;
    //
    //
    // protected override async Task OnInitializedAsync()
    // {
    //     myApiClient =  _HttpClientFactorylient.CreateClient("MyApi");
    //     HubServices.ConfigureOnNewMessage(NewMessageReceived);
    // }
    //
    // private void NewMessageReceived(string message)
    // {
    //     _messages.Add(message);
    //     _localStorage.SetItemAsync("message", message);
    //     InvokeAsync(StateHasChanged);
    // }
    //
    // private void SendMessage()
    // {
    //     myApiClient.PostAsJsonAsync("chat","Hellow");
    // }
}