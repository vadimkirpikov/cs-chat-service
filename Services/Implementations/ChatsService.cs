using AutoMapper;
using ChatService.Models.Domain;
using ChatService.Models.Dto;
using ChatService.Repositories;
using ChatService.Repositories.Interfaces;
using ChatService.Services.Interfaces;

namespace ChatService.Services.Implementations;

public class ChatsService(IChatRepository repository, IMapper mapper) : Service<Chat, ChatDto>(repository, mapper), IChatService
{
    public async Task<IEnumerable<Chat>> GetChatsOfUserAsync(int userId, int page, int pageSize)
    {
        return await repository.GetChatsOfUserAsync(userId, page, pageSize);
    }

    public async Task<Chat> GetChatOfBothUsersAsync(int firstUserId, int secondUserId)
    {
        var chat = await repository.GetChatOfBothUsersAsync(firstUserId, secondUserId);
        if (chat == null)
        {
            throw new KeyNotFoundException("There is no chat between these users");
        }
        return chat;
    }
}