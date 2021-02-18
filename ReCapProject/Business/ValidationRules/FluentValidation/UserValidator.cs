using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).Length(8, 30);
            RuleFor(user => user.Password).Must(ContainCapitalLetter).WithMessage("Şifre büyük harf içermelidir");

            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MaximumLength(50);

            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MaximumLength(30);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MaximumLength(30);

        }

        private bool ContainCapitalLetter(string arg)
        {
            foreach (var letter in arg)
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }
    }
}
