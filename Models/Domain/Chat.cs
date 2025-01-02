namespace ChatService.Models.Domain;

public class Chat
{
    public int Id { get; set; }
    public int FirstUserId { get; set; }
    public int SecondUserId { get; set; }
    public ICollection<Message>? Messages { get; set; }
}