using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarModelManager : ICarModelService
    {
        ICarModelDal _carModelDal;

        public CarModelManager(ICarModelDal carModelDal)
        {
            _carModelDal = carModelDal;
        }

        [ValidationAspect(typeof(CarModelValidator))]
        public IResult Add(CarModel carModel)
        {
            IResult result = BusinessRules.Run(CheckIfModelNameOfExists(carModel.Name));

            if (result!=null)
            {
                return result;
            }
            _carModelDal.Add(carModel);
            return new SuccessResult(Messages.CarModelAdded);
        }

        private IResult CheckIfModelNameOfExists(string modelName)
        {
            var result = _carModelDal.GetAll(p => p.Name == modelName).Any();
            if (!result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ModelNameMustUnique);
        }

        public IResult Delete(CarModel carModel)
        {
            _carModelDal.Delete(carModel);
            return new SuccessResult(Messages.CarModelDeleted);
        }

        public IDataResult<List<CarModel>> GetAll()
        {
            return new SuccessDataResult<List<CarModel>>(_carModelDal.GetAll());
        }

        public IDataResult<CarModel> GetById(int id)
        {
            return new SuccessDataResult<CarModel>(_carModelDal.Get(c=>c.Id==id));
        }

        public IResult Update(CarModel carModel)
        {
            _carModelDal.Update(carModel);
            return new SuccessResult(Messages.CarModelUpdated);
        }
    }
}
