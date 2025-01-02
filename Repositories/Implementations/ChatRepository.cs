using ChatService.Data;
using ChatService.Models.Domain;
using ChatService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories.Implementations;

public class ChatRepository(ApplicationDbContext context): Repository<Chat>(context),  IChatRepository
{
   

    public async Task<IEnumerable<Chat>> GetChatsOfUserAsync(int userId, int page, int pageSize)
    {
        return await Context.Chats.Where(c => c.FirstUserId == userId || c.SecondUserId == userId)
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Chat?> GetChatOfBothUsersAsync(int firstUserId, int secondUserId)
    {
        return await Context.Chats.SingleOrDefaultAsync(c => c.FirstUserId == firstUserId
            && c.SecondUserId == secondUserId
            || c.FirstUserId == secondUserId
            && c.SecondUserId == firstUserId);
    }
}