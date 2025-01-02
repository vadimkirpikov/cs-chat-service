using ChatService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
}