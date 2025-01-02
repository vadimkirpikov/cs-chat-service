using ChatService.Data;
using ChatService.Models.Domain;
using ChatService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Repositories.Implementations;

public class MessageRepository(ApplicationDbContext context) : Repository<Message>(context), IMessageRepository
{

    public async Task<IEnumerable<Message>> GetMessagesOfChatAsync(int chatId, int page, int pageSize)
    {
        return await Context.Messages.OrderByDescending(m => m.ChatId).Skip((page - 1) * pageSize).Take(pageSize)
            .OrderBy(m => m.Id).ToListAsync();
    }
    
}