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
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		[ValidationAspect(typeof(BrandValidator))]
		public IResult Add(Brand brand)
        {
			IResult result = BusinessRules.Run(CheckIfBrandNameOfExists(brand.Name));
            if (result!=null)
            {
				return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

		private IResult CheckIfBrandNameOfExists(string brandName)
        {
			var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (!result)
            {
				return new SuccessResult(); 
            }
			return new ErrorResult(Messages.BrandNameMustUnique);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
		}

        public IResult Update(Brand brand)
		{
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
