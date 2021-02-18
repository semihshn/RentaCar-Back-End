using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalDetailValidator : AbstractValidator<RentalDetailDto>
    {
        public RentalDetailValidator()
        {
            RuleFor(r => r.CarName).MinimumLength(40);//RentalManager'daki GetRentalDetailsDto fonksiyonunda kullanıyorum ama çalışmıyor
           // RuleFor(r => r.ReturnDate).
        }
    }
}
