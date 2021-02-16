using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userService;

        public UserManager(IUserDal userService)
        {
            _userService = userService;
        }

        public IResult Add(User user)
        {
            _userService.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userService.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userService.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userService.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            _userService.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
