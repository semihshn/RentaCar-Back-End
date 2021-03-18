using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using System.Linq.Expressions;

namespace Business.Abstract
{
	public interface ICarService
	{
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);

        IDataResult<List<CarDetailDto>> GetCarsBySelect(int brandId, int colorId);
    }
}
