using FluentValidation;

namespace EduSubscription.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanCommandValidator()
    {
        RuleFor(o => o.Description).NotEmpty().MaximumLength(200);
        RuleFor(o => o.Installments).NotEmpty().GreaterThan(1);
    }
}