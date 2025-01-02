using ChatService.Models.Domain;

namespace ChatService.Repositories.Interfaces;

public interface IChatRepository: IRepository<Chat>
{
    Task<IEnumerable<Chat>> GetChatsOfUserAsync(int userId, int page, int pageSize);
    Task<Chat?> GetChatOfBothUsersAsync(int firstUserId, int secondUserId);
}