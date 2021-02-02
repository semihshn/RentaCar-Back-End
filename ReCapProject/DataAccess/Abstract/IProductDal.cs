using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IProductDal
	{
		//GetById, GetAll, Add, Update, Delete
		List<Product> GetAll();
		void Add(Product product);
		void Update(Product product);
		void Delete(Product product);
		List<Product> GetById(int brandId, int colorId);

	}
}
