using Application.Requests;
using FluentValidation;

namespace Application.Validators;

public class SendEmailRequestValidator : AbstractValidator<SendEmailRequest>
{
    public SendEmailRequestValidator()
    {
        RuleFor(x => x.To)
            .NotEmpty().WithMessage("Recipient email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.TemplateCode)
            .NotEmpty().WithMessage("Template code is required.");

        RuleFor(x => x.Parameters)
            .NotNull().WithMessage("Parameters dictionary cannot be null.");
    }
}
