using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
	public class EfCarDal : ICarDal
	{
		public void Add(Car entity)
		{
			if (entity.Description.Length>2 && entity.DailyPrice>0)
			{
				using (NorthwindContext context = new NorthwindContext())
				{
					var addedEntity = context.Entry(entity);
					addedEntity.State = EntityState.Added;
					context.SaveChanges();
				}
			}
			else
			{
				Console.WriteLine("Araç ismi 2 karakterden büyük olmalı ve günlük fiyat poizitif bir değer olmalıdır.");
			}

		}

		public void Delete(Car entity)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				return context.Set<Car>().SingleOrDefault(filter);
			}
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			using(NorthwindContext context=new NorthwindContext())
			{
				return filter == null
					? context.Set<Car>().ToList()
					: context.Set<Car>().Where(filter).ToList();
			}
		}

		public void Update(Car entity)
		{
			using(NorthwindContext context=new NorthwindContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
