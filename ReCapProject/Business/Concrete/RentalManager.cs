using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;


        public RentalManager(IRentalDal rentalDal,ICarService carService,ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarExistInRentalList(rental), ChecCarExistRentalHistory(rental), ChecIfCarOfFindeksPoint(rental), ChecIfCustomerOfFindeksPoint(rental), ChecIfFindeksPoint(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(I => I.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarDetails(filter), Messages.ReturnedRental);
        }

		[ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckCarExistInRentalList(Rental rental)
        {
            if (rental.ReturnDate == null && _rentalDal.GetCarDetails(I => I.CarId == rental.CarId).Count > 0)
            {
                return new ErrorResult(Messages.FailedRentalAddOrUpdate);
            }

            return new SuccessResult();
        }

        private IResult ChecCarExistRentalHistory(Rental rental)
        {

            List<Rental> rentalList = _rentalDal.GetAll(r => r.CarId == rental.CarId);
			for (int i = 0; i < rentalList.Count; i++)
			{
                if (rentalList[i]== null)
                {
                    return new SuccessResult();
                }
                else if(rentalList[i].ReturnDate>rental.RentDate)
                {
                    return new ErrorResult(Messages.AlreadyRented);
                }
            }
            return new SuccessResult();
            
        }

        private IResult ChecIfCarOfFindeksPoint(Rental rental)
        {

            var car = _carService.GetById(rental.CarId);
			if (car.Data.FindeksPoint==null)
			{
                return new ErrorResult(Messages.ErrorCarFindeksPoint);
			}
            return new SuccessResult();
        }

        private IResult ChecIfCustomerOfFindeksPoint(Rental rental)
        {

            var customer = _customerService.GetById(rental.CustomerId);
            if (customer.Data.FindeksPoint == null)
            {
                return new ErrorResult(Messages.ErrorCustomerFindeksPoint);
            }
            return new SuccessResult();
        }

        private IResult ChecIfFindeksPoint(Rental rental)
        {

            var customer = _customerService.GetById(rental.CustomerId);
            var car = _carService.GetById(rental.CarId);
            if (customer.Data.FindeksPoint<car.Data.FindeksPoint)
            {
                return new ErrorResult(Messages.InsufficientFindeksScore);
            }
            return new SuccessResult();
        }
    }
}
