using System.Data;
using FluentValidation;

namespace EduSubscription.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(o => o.IdPlan).NotEmpty();
        RuleFor(o => o.Value).GreaterThan(1).NotEmpty();
    }
}