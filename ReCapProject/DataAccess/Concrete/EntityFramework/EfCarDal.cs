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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join m in context.Models
                             on c.ModelId equals m.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName=b.Name+" "+m.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath=ci.ImagePath,
                                 Date=ci.Date
                             };
                return result.ToList();
            }
        }
    }
}

