using Blazored.LocalStorage;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRSample.Frontend.HubServise;

public class ChatHubServices
{
    private HubConnection _hubConnection;

    public string? connectionId;

    public ChatHubServices(ILocalStorageService localStorageService)
    {
        try
        {
            _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7201/hub/chat",
                    options =>
                    {
                        options.AccessTokenProvider = () =>Task.FromResult(localStorageService.GetItemAsync<string>("token").ToString());
                    })
                .WithAutomaticReconnect().Build();
            _hubConnection.StartAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ConfigureOnNewMessage(Action<string> onNewMessage)
    {
        _hubConnection.On<string>("NewMessage", onNewMessage);
    }
}