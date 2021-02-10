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

			//TestAddNewBrand("Renoult");

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

			Console.WriteLine("{0}/{1}", brandManager.GetById(id).Id, brandManager.GetById(id).Name);
		}

		private static void TestGetAllBrand()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			foreach (var brand in brandManager.GetAll())
			{
				Console.WriteLine("{0}/{1}", brand.Id, brand.Name);
			}
		}

		private static void TestGetAllColor()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());

			foreach (var color in colorManager.GetAll())
			{
				Console.WriteLine("{0}/{1}", color.Id, color.Name);
			}
		}

		private static void TestGetAllCarModel()
		{
			CarModelManager carModelManager = new CarModelManager(new EfCarModelDal());

			foreach (var carmodel in carModelManager.GetAll())
			{
				Console.WriteLine("{0}/{1}/{2}", carmodel.Id, carmodel.BrandId, carmodel.Name);
			}
		}

		private static void TestGetCarDetails()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			foreach (var car in carManager.GetCarDetails())
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
			EfCarDal efCarDal = new EfCarDal();

			efCarDal.Add(new Car()
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
			EfCarModelDal efCarModelDal = new EfCarModelDal();

			efCarModelDal.Add(new CarModel()
			{
				BrandId = brandId,
				Name = name
			});
		}

		private static void TestAddNewBrand(string name)
		{
			EfBrandDal efBrandDal = new EfBrandDal();

			efBrandDal.Add(new Brand()
			{
				Name = name
			});
		}

		private static void TestAddNewColor(string name)
		{
			EfColorDal efColorDal = new EfColorDal();

			efColorDal.Add(new Color()
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

			foreach (var car in carManager.GetCarsByColorId(id))
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

			foreach (var car in carManager.GetCarsByBrandId(id))
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

			foreach (var car in carManager.GetAll())
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
