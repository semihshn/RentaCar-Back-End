using Core.DataAccess;
using Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
	public interface IRentalDal : IEntityRepository<Rental>
	{
		List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null);
	}
}
