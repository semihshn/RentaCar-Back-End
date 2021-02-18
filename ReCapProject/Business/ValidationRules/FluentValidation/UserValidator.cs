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
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).CreditCard();
        }
    }
}
