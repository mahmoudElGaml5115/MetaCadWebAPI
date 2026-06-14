using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using FluentValidation;
using MetaCad.Application.Models.Auth;

namespace MetaCad.Application.Validators.Auth; 
public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.CountryCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(14);
    }
}