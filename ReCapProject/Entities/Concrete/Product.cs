using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Product : IEntity
	{
		//Id, BrandId, ColorId, ModelYear, DailyPrice, Description

		public int Id { get; set; }

		public int BrandId { get; set; }

		public int ColorId { get; set; }

		public string ModelYear { get; set; }

		public int DailyPrice { get; set; }

		public string Description { get; set; }
	}
}
