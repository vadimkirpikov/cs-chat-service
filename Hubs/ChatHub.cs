using ChatService.Models.Dto;
using ChatService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs;

[Authorize(AuthenticationSchemes = "Client")]
public class ChatHub(IMessageService messageService, IChatService chatService): Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }

    public async Task JoinChat(int chatId)
    {
        await chatService.GetAsync(chatId);
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    }

    public async Task SendMessage(MessageDto messageDto)
    {
        var message = await messageService.CreateAsync(messageDto);
        await Clients.Group(messageDto.ChatId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}