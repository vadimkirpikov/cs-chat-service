namespace ChatService.Models.Dto;

public class MessageDto
{
    public int SenderId { get; set; }
    public int ChatId { get; set; }
    public required string Content { get; set; }
}