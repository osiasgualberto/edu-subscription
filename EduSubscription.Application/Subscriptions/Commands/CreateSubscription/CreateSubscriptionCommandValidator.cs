using FluentValidation;

namespace EduSubscription.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(o => o.IdPlan).NotEmpty();
    }
}