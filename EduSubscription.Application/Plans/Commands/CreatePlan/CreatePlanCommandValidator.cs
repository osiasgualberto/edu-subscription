using FluentValidation;

namespace EduSubscription.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanCommandValidator()
    {
        RuleFor(o => o.Description).NotEmpty();
        RuleFor(o => o.DurationInMonths).GreaterThan(1);
    }    
}