using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();

            RuleFor(r => r.CarId).Must(RentControll).WithMessage("Eklenmek istenen araç zaten kiralanmış");
        }

        private bool RentControll(int arg)
        {
            IRentalDal _rentalDal=new EfRentalDal();

            var result = _rentalDal.GetRentalDetails(x => x.CarId == arg);
            return result.Count > 0 ? true : false;
        }
    }
}
