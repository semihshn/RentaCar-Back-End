using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
		IDataResult<List<Rental>> GetAll();
		IDataResult<Rental> GetById(int id);
		IDataResult<List<Rental>> GetRentalsByCarId(int id);
		IDataResult<List<Rental>> GetRentalsByCustomerId(int id);
		IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int id);

		IResult CheckReturnDate(int carId);
		IResult Add(Rental rental);
		IResult Update(Rental rental);
		IResult Delete(Rental rental);
	}
}
