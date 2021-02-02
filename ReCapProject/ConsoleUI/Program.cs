using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			ProductManager productManager = new ProductManager(new InMemoryProductDal());

			var result=productManager.GetAll();

			foreach (var item in result)
			{
				Console.Write("Id={0} ",item.Id);
				Console.Write("BrandId={0} ",item.BrandId);
				Console.Write("ColorId={0} ", item.ColorId);
				Console.Write("DailyPrice={0} ", item.DailyPrice);
				Console.Write("ModelYear={0} ", item.ModelYear);
				Console.Write("Description={0} ", item.Description);
				Console.WriteLine();
			}
		}
	}
}
