using EduSubscription.Application.Subscriptions.Commands.CreateSubscription;
using FluentValidation;

namespace EduSubscription.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public DeleteSubscriptionCommandValidator()
    {
        RuleFor(o => o.IdPlan).NotEmpty();
    }
}