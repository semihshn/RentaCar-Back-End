using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;

        public CustomerManager(ICustomerDal customerDal,IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Customer>> GetCustomersByUserId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<CustomerAndUserUpdateDto> GetCustomerAndUserDetails(int userId)
        {
            return new SuccessDataResult<CustomerAndUserUpdateDto>(_customerDal.GetCustomerAndUserDetails(userId));
        }

        public IResult UpdateCustomerAndUser(CustomerAndUserUpdateDto customerUpdateDto)
        {
            var userResult = _userService.GetById(customerUpdateDto.Id);
            if (!userResult.Success)
                return new ErrorResult(userResult.Message);

            if (!HashingHelper.VerifyPasswordHash(customerUpdateDto.ActivePassword, userResult.Data.PasswordHash, userResult.Data.PasswordSalt))
                return new ErrorResult(Messages.PasswordError);

            var customerResult = _customerDal.Get(p => p.UserId == customerUpdateDto.Id);
            if (customerResult == null)
                return new ErrorResult(Messages.CustomerNotFound);

            customerResult.CompanyName = customerUpdateDto.CompanyName;

            userResult.Data.FirstName = customerUpdateDto.FirstName;
            userResult.Data.LastName = customerUpdateDto.LastName;
            userResult.Data.Email = customerUpdateDto.Email;

            if (customerUpdateDto.NewPassword.Length > 5)
            {
                HashingHelper.CreatePasswordHash(customerUpdateDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                userResult.Data.PasswordHash = passwordHash;
                userResult.Data.PasswordSalt = passwordSalt;
            }

			try
			{
                _customerDal.Update(customerResult);
            }
			catch (Exception)
			{
                return new ErrorResult(Messages.CustomerNotUpdated);
            }
			try
			{
                _userService.Update(userResult.Data);
            }
			catch (Exception)
			{
                return new ErrorResult(Messages.UserNotUpdated);
            }

            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
