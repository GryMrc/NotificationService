using Application.Requests;
using FluentValidation;

namespace Application.Validators;

public class SendPushRequestValidator : AbstractValidator<SendPushRequest>
{
    public SendPushRequestValidator()
    {
        RuleFor(x => x.DeviceToken)
            .NotEmpty().WithMessage("Device token is required.");

        RuleFor(x => x.TemplateCode)
            .NotEmpty().WithMessage("Template code is required.");

        RuleFor(x => x.Parameters)
            .NotNull().WithMessage("Parameters dictionary cannot be null.");
    }
}
