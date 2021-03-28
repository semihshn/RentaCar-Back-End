using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
	{
		public CustomerAndUserUpdateDto GetCustomerAndUserDetails(int userId)
		{
            using (ReCapContext context = new ReCapContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             where user.Id==userId
                             select new CustomerAndUserUpdateDto
                             {
                                 Id = user.Id,
                                 CustomerId=customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email
                             };

                return result.FirstOrDefault();
            }
        }
	}
}
