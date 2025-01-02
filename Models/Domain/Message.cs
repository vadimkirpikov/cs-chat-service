using System.ComponentModel.DataAnnotations;

namespace ChatService.Models.Domain;

public class Message
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime SendTime { get; set; } = DateTime.UtcNow;
    [MaxLength(350)]
    public required string Content { get; set; }
    
    
    public int ChatId { get; set; }
    public Chat? Chat { get; set; }
    
}