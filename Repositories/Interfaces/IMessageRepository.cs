using ChatService.Models.Domain;

namespace ChatService.Repositories.Interfaces;

public interface IMessageRepository: IRepository<Message>
{
    Task<IEnumerable<Message>> GetMessagesOfChatAsync(int chatId, int page, int pageSize);
}