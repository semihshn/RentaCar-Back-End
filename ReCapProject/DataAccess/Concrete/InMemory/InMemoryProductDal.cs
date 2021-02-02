using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		List<Product> _products;
		public InMemoryProductDal()
		{
			   _products = new List<Product> {
					new Product{Id=1,BrandId=1,ColorId=1,ModelYear="2006",DailyPrice=120,Description="Emsalsiz"},
					new Product{Id=2,BrandId=5,ColorId=3,ModelYear="2010",DailyPrice=120,Description="Fena Başa Bela"},
					new Product{Id=3,BrandId=4,ColorId=5,ModelYear="2018",DailyPrice=120,Description="Arabama Güveniyorum"},
					new Product{Id=4,BrandId=9,ColorId=7,ModelYear="2001",DailyPrice=120,Description="Nokta Hata Yok , Ağır Hasarlı , Ölücüler Yazmasın"},
				};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);

			_products.Remove(productToDelete);
		}

		public List<Product> GetAll()
		{
			return _products;
		}

		public List<Product> GetById(int brandId,int colorId)
		{
			return _products.Where(p=>p.BrandId==brandId&&p.ColorId==colorId).ToList();
		}

		public void Update(Product product)
		{
			Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
			productToUpdate.ColorId = product.ColorId;
			productToUpdate.BrandId = product.BrandId;
			productToUpdate.ModelYear = product.ModelYear;
			productToUpdate.DailyPrice = product.DailyPrice;
			productToUpdate.Description = product.Description;
		}
	}
}
