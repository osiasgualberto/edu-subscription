namespace EduSubscription.Infrastructure.Persistence.Common.Outbox;

public class OutboxMessage
{
    public OutboxMessage()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool Processed { get; set; }
    public DateTime CreatedAt { get; set; }
}