using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarModelService
    {
        IDataResult<List<CarModel>> GetAll();
        IDataResult<CarModel> GetById(int id);

        IResult Add(CarModel carModel);
        IResult Update(CarModel carModel);
        IResult Delete(CarModel carModel);
    }
}
