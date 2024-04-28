namespace EduSubscription.Infrastructure.Persistence.Common.Outbox;

public class OutboxMessage
{
    public OutboxMessage()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool Processed { get; set; }
    public DateTime CreatedAt { get; set; }
}