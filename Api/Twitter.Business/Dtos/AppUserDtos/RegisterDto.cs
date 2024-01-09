using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Dtos.AppUserDtos;

public class RegisterDto
{
    public string Fullname { get; set; }
    public DateTime Birthdate { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator() 
    {
        RuleFor(r => r.Fullname)
            .NotNull()
            .NotEmpty()
            .MaximumLength(32)
            .MinimumLength(5);
        RuleFor(r => r.Birthdate)
            .NotNull()
            .NotEmpty()
            .GreaterThan(DateTime.Now.AddYears(-100))
                 .WithMessage("You are too old to be able to use this site")
            .LessThan(DateTime.Now.AddYears(-18))
                 .WithMessage("You are too young to be using this site");
        RuleFor(r => r.Username)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64);
        RuleFor(r => r.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();
        RuleFor(r => r.Password)
            .NotEmpty()
            .NotNull()
            .Matches(@"^(?=.*[a-z](?=.*[A-Z](?=.*\d).{6,}$");
    }
}