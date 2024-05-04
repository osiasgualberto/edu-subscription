using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommand : IRequest<Result>
{
    public DeleteSubscriptionCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}