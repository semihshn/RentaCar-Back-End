using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestGetAllCar();

			//TestGetAllBrand();

			//TestGetAllColor();

			//TestGetAllCarModel();


			//TestAddNewCar(3,5,2,"2020",250,"Mercedes Motoru");

			//TestAddNewBrand("Ferrari");

			//TestAddNewColor("Beyaz");

			//TestAddNewCarModel(2, "Clio");


			//TestGetCarsByBrandId(2);

			//TestGetBrandById(1);

			//TestGetCarsByColorId(1);

			//TestDeleteCar(4);



			//TestGetCarDetails();


		}

		private static void TestGetBrandById(int id)
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			var result = brandManager.GetById(id);

			Console.WriteLine("{0}/{1}", result.Data.Id, result.Data.Name);
		}

		private static void TestGetAllBrand()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			var result = brandManager.GetAll();

			foreach (var brand in result.Data)
			{
				Console.WriteLine("{0}/{1}", brand.Id, brand.Name);
			}
		}

		private static void TestGetAllColor()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());

			var result = colorManager.GetAll();

			foreach (var color in result.Data)
			{
				Console.WriteLine("{0}/{1}", color.Id, color.Name);
			}
		}

		private static void TestGetAllCarModel()
		{
			CarModelManager carModelManager = new CarModelManager(new EfCarModelDal());

			var result = carModelManager.GetAll();

			foreach (var carmodel in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}", carmodel.Id, carmodel.BrandId, carmodel.Name);
			}
		}

		private static void TestGetCarDetails()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarDetails();

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}",
					car.CarName,
					car.ColorName,
					car.BrandName,
					car.DailyPrice);
			}
		}

		private static void TestAddNewCar(int brandId , int modelId , int colorId , string modelYear , int dailyPrice , string description)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			carManager.Add(new Car()
			{
				BrandId = brandId,
				ModelId = modelId,
				ColorId = colorId,
				ModelYear = modelYear,
				DailyPrice = dailyPrice,
				Description = description

			});
		}

		private static void TestAddNewCarModel(int brandId , string name)
		{
			CarModelManager carModelManager = new CarModelManager(new EfCarModelDal());

			carModelManager.Add(new CarModel()
			{
				BrandId = brandId,
				Name = name
			});
		}

		private static void TestAddNewBrand(string name)
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			brandManager.Add(new Brand()
			{
				Name = name
			});
		}

		private static void TestAddNewColor(string name)
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());

			colorManager.Add(new Color()
			{
				Name = name
			});
		}

		private static void TestDeleteCar(int id)
		{
			ReCapContext reCapContext = new ReCapContext();
			reCapContext.Cars.Remove(reCapContext.Cars.SingleOrDefault(c => c.Id == id));
			reCapContext.SaveChanges();
		}

		private static void TestGetCarsByColorId(int id)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarsByColorId(id);

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}/{4}/{5}/{6}",
					car.Id,
					car.BrandId,
					car.ModelId,
					car.ColorId,
					car.DailyPrice,
					car.ModelYear,
					car.Description);
			}
		}

		private static void TestGetCarsByBrandId(int id)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarsByBrandId(id);

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}/{4}/{5}/{6}",
					car.Id,
					car.BrandId,
					car.ModelId,
					car.ColorId,
					car.DailyPrice,
					car.ModelYear,
					car.Description);
			}
		}

		private static void TestGetAllCar()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetAll();

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}/{4}/{5}/{6}",
					car.Id,
					car.BrandId,
					car.ModelId,
					car.ColorId,
					car.DailyPrice,
					car.ModelYear,
					car.Description);
			}
		}
	}
}
