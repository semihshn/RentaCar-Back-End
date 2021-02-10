using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class CarModel : IEntity
	{

		public int Id { get; set; }

		public int BrandId { get; set; }

		public string Name { get; set; }
	}
}
