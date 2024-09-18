using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Backend.Hubs;

public class Chathub(IHubContext<Chathub> hubContext) : Hub
{
    public async Task SendMessage(string message)
    {
        await hubContext.Clients.All.SendAsync("NewMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"******** + {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }
}