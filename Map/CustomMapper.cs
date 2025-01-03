using AutoMapper;
using ChatService.Models.Domain;
using ChatService.Models.Dto;

namespace ChatService.Map;

public class CustomMapper: Profile
{
    public CustomMapper()
    {
        CreateMap<MessageDto, Message>();
        CreateMap<Message, MessageDto>();
        CreateMap<ChatDto, Chat>();
        CreateMap<Chat, ChatDto>();
    }
}