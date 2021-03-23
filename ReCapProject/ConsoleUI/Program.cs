using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
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

			//TestUserGetAll();

			//TestGetAllCustomer();

			//TestGetAllRentals();


			//TestAddNewCar(3,4,5,"1984",500,"Kırmızı şeytan");

			//TestAddNewBrand("A");

			//TestAddNewColor("Sarı");

			//TestAddNewCarModel(3, "288 GTO");

			//TestUserAdd("Melike","Belpınar","mlk_blp@hotmail.com","12345689");

			//TestAddNewCustomer(2,"BorsaBiziz A.S");

			//TestAddNewRentalCar(9,4);

			TestAddNewCreditCard("1234567894521452", "123", "156", 4);




			//TestGetCarsByBrandId(2);

			//TestGetBrandById(1);

			//TestGetCarsByColorId(1);

			//TestDeleteCarModel(3);
			//TestDeleteCar(3);
			//TestDeleteBrand(5);
			//TestDeleteColor(3);
			//TestDeleteRental(23);

			//TestDeleteCarImage(9);
			//TestGetAllCarImage();

			//TestGetCarDetails(4);

			//TestGetRentalDetailsDto();

		}

        private static void TestGetRentalDetailsDto()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //var result = rentalManager.GetRentalDetailsDto();

           // foreach (var rentals in result.Data)
            {
                //Console.WriteLine("{0}/{1}/{2}//{3}//{4}/{5}/{6}", rentals.Id, rentals.CarId, rentals.CarName, rentals.UserName, rentals.CustomerName, rentals.RentDate, rentals.ReturnDate);
            }
        }

        private static void TestDeleteRental(int id)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Delete(new Rental() { Id = id });
        }

        private static RentalManager TestGetAllRentals()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();

            foreach (var rentals in result.Data)
            {
                Console.WriteLine("{0}/{1}/{2}//{3}//{4}", rentals.Id, rentals.CarId, rentals.CustomerId, rentals.RentDate, rentals.ReturnDate);
            }

            return rentalManager;
        }

        private static RentalManager TestAddNewRentalCar(int carId, int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

			rentalManager.Add(new Rental()
			{
				CarId = carId,
				CustomerId = customerId
			});
            return rentalManager;
        }

		private static CreditCardManager TestAddNewCreditCard(string cardNumber,string cvc,string expiration, int customerId)
		{
			CreditCardManager creditCardManager = new CreditCardManager(new EfCreditCardDal());

			creditCardManager.Pay(new CreditCard()
			{
				CardNumber=cardNumber,
				Cvc=cvc,
				Expiration=expiration,
				CustomerId = customerId
			});
			return creditCardManager;
		}

		private static void TestGetAllCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            foreach (var customer in result.Data)
            {
                Console.WriteLine("{0}/{1}/{2}", customer.Id, customer.UserId, customer.CompanyName);

            }
        }

        private static CustomerManager TestAddNewCustomer(int id, string companyName)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer()
            {
                UserId = id,
                CompanyName = companyName,
            });
            return customerManager;
        }

        private static void TestUserGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("{0}/{1}/{2}/{3}/{4}", user.Id, user.FirstName, user.LastName, user.Email);
            }
        }

        private static UserManager TestUserAdd(string firstName, string lastName, string eMail, string password)
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = eMail
			});
            return userManager;
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

		private static void TestGetAllCarImage()
		{
			CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());

			var result = carImageManager.GetAll();

			foreach (var carImage in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}", carImage.Id,carImage.CarId,carImage.ImagePath,carImage.Date);
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
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetById(id);
			carManager.Delete(result.Data);
		}

		private static void TestDeleteCarImage(int id)
		{
			CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());
			var result = carImageManager.GetById(id);
			carImageManager.Delete(result.Data);
		}

		private static void TestDeleteBrand(int id)
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			var result = brandManager.GetById(id);
			brandManager.Delete(result.Data);
		}

		private static void TestDeleteColor(int id)
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			var result = colorManager.GetById(id);
			colorManager.Delete(result.Data);
		}

		private static void TestDeleteCarModel(int id)
		{
			CarModelManager carModelManager = new CarModelManager(new EfCarModelDal());
			var result = carModelManager.GetById(id);
			carModelManager.Delete(result.Data);
		}

		private static void TestGetCarsByColorId(int id)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarDetails(c=>c.ColorId==id);

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}/{4}/{5}/{6}",
					//car.Id,
					//car.BrandId,
					//car.ModelId,
					//car.ColorId,
					car.DailyPrice,
					car.ModelYear,
					car.Description);
			}
		}

		private static void TestGetCarsByBrandId(int id)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarDetails(c=>c.BrandId==id);

			foreach (var car in result.Data)
			{
				Console.WriteLine("{0}/{1}/{2}/{3}/{4}/{5}/{6}",
					//car.Id,
					//car.BrandId,
					//car.ModelId,
					//car.ColorId,
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
