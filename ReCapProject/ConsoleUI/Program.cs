using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{


			CarManager carManager = new CarManager(new EfCarDal());

			EfCarDal efCarDal = new EfCarDal();
			efCarDal.Add(new Car()
			{
				BrandId=3,
				ColorId=1,
				ModelYear="2008",
				DailyPrice=100,
				Description="F"
				
			});

			Console.WriteLine("Tüm Araçlar");
			foreach (var cars in carManager.GetAll())
			{
				Console.Write("Id={0} ", cars.Id);
				Console.Write("BrandId={0} ", cars.BrandId);
				Console.Write("ColorId={0} ", cars.ColorId);
				Console.Write("DailyPrice={0} ", cars.DailyPrice);
				Console.Write("ModelYear={0} ", cars.ModelYear);
				Console.Write("Description={0} ", cars.Description);
				Console.WriteLine();
			}
			Console.WriteLine("--------------------");
			Console.WriteLine("BrandId değeri 3 olan araçlar");
			foreach (var cars in carManager.GetCarsByBrandId(3))
			{
				Console.Write("Id={0} ", cars.Id);
				Console.Write("BrandId={0} ", cars.BrandId);
				Console.Write("ColorId={0} ", cars.ColorId);
				Console.Write("DailyPrice={0} ", cars.DailyPrice);
				Console.Write("ModelYear={0} ", cars.ModelYear);
				Console.Write("Description={0} ", cars.Description);
				Console.WriteLine();
			}

			Console.WriteLine("--------------------");
			Console.WriteLine("ColorId değeri 1 olan araçlar");
			foreach (var cars in carManager.GetCarsByColorId(1))
			{
				Console.Write("Id={0} ", cars.Id);
				Console.Write("BrandId={0} ", cars.BrandId);
				Console.Write("ColorId={0} ", cars.ColorId);
				Console.Write("DailyPrice={0} ", cars.DailyPrice);
				Console.Write("ModelYear={0} ", cars.ModelYear);
				Console.Write("Description={0} ", cars.Description);
				Console.WriteLine();
			}
		}
	}
}
