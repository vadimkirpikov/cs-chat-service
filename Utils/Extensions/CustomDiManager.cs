

using ChatService.Repositories.Implementations;
using ChatService.Repositories.Interfaces;
using ChatService.Services.Implementations;
using ChatService.Services.Interfaces;

namespace ChatService.Utils.Extensions;

public static class CustomDiManager
{
    public static WebApplicationBuilder InjectDependencies(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IChatRepository, ChatRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<IMessageService, MessageService>()
            .AddScoped<IChatService, ChatsService>()
            .AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
            });
        return builder;
    }
}