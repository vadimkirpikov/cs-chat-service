using ChatService.Models.Domain;
using ChatService.Models.Dto;

namespace ChatService.Services.Interfaces;

public interface IMessageService: IService<Message, MessageDto>
{
    Task<IEnumerable<Message>> GetMessagesOfChatAsync(int chatId, int page, int pageSize);

}