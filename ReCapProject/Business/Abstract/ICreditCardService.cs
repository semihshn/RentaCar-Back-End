using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
	public interface ICreditCardService
	{
		IDataResult<List<CreditCard>> GetCreditCards(Expression<Func<CreditCard, bool>> filter = null);
		IResult Pay(CreditCard creditCard);
	}
}
