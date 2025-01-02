using ChatService.Models.Domain;

namespace ChatService.Services.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<Message>> GetMessagesOfChatAsync(int chatId, int page, int pageSize);

}