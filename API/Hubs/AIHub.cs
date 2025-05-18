using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class AIHub : Hub
{
    public string GetConnectionId() => Context.ConnectionId;
}
