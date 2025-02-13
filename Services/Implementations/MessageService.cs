using AutoMapper;
using ChatService.Models.Domain;
using ChatService.Models.Dto;
using ChatService.Repositories.Interfaces;
using ChatService.Services.Interfaces;

namespace ChatService.Services.Implementations;

public class MessageService(IMessageRepository repository, IMapper mapper) : Service<Message, MessageDto>(repository, mapper), IMessageService
{
    public async Task<IEnumerable<Message>> GetMessagesOfChatAsync(int chatId, int page, int pageSize)
    {
        return await repository.GetMessagesOfChatAsync(chatId, page, pageSize);
    }

    public async Task EditPersonalMessageAsync(int id, MessageDto messageDto)
    {
        var message = await GetAsync(id);
        if (message.SenderId != messageDto.SenderId)
        {
            throw new ArgumentException("Sender id does not match");
        }
        await UpdateAsync(id, messageDto);
    }
}