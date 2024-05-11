using FluentValidation;

namespace EduSubscription.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanCommandValidator()
    {
        RuleFor(o => o.Description).NotEmpty().MaximumLength(200);
        RuleFor(o => o.Installments).NotEmpty().GreaterThan(1);
    }    
}