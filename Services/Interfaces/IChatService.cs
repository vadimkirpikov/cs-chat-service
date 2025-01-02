using ChatService.Models.Domain;
using ChatService.Models.Dto;

namespace ChatService.Services.Interfaces;

public interface IChatService: IService<Chat, ChatDto>
{
    Task<IEnumerable<Chat>> GetChatsOfUserAsync(int userId, int page, int pageSize);
    Task<Chat> GetChatOfBothUsersAsync(int firstUserId, int secondUserId);
}