using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car,ReCapContext> , ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCapContext reCapContext = new ReCapContext())
			{
				var result = from ca in reCapContext.Cars
							 join b in reCapContext.Brands
							 on ca.BrandId equals b.Id
							 join co in reCapContext.Colors
							 on ca.ColorId equals co.Id
							 join m in reCapContext.Models
							 on ca.ModelId equals m.Id
							 select new CarDetailDto
							 {
								 CarName = b.Name + " " + m.Name,
								 BrandName = b.Name,
								 ColorName = co.Name,
								 DailyPrice = ca.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}
