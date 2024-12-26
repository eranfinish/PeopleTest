using FluentValidation;
using PeopleTest.Models;

namespace PeopleTest.Core.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.IdNumber)
                .NotEmpty().WithMessage("IdNumber is required")
                .Length(9).WithMessage("IdNumber must have 9 digits exactly")
                .Matches(@"^\d+$").WithMessage("IdNumber must be numeric");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is reqired")
                .MaximumLength(100).WithMessage("Name must not be over 100 characters");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Address is elegal")
                .When(p => !string.IsNullOrEmpty(p.Email));

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Birthday is required")
                .LessThan(DateTime.Today).WithMessage("Date must be in the past");

            RuleFor(p => p.Phone)
                .Matches(@"^\d+$").WithMessage("Phone must be a number")
                .When(p => !string.IsNullOrEmpty(p.Phone));

            RuleFor(p => p.Gender)
                .Must(g => string.IsNullOrEmpty(g.ToLower()) || new[] { "fmale", "male", "else" }.Contains(g))
                .WithMessage("gender is elegal");
        }
    }
}
