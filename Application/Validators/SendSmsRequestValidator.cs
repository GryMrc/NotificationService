using Application.Requests;
using FluentValidation;

namespace Application.Validators;

public class SendSmsRequestValidator : AbstractValidator<SendSmsRequest>
{
    public SendSmsRequestValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("A valid phone number is required.");

        RuleFor(x => x.TemplateCode)
            .NotEmpty().WithMessage("Template code is required.");

        RuleFor(x => x.Parameters)
            .NotNull().WithMessage("Parameters dictionary cannot be null.");
    }
}
