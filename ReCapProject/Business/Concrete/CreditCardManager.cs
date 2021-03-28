using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class CreditCardManager : ICreditCardService
	{

		ICreditCardDal _creditCardDal;

		public CreditCardManager(ICreditCardDal creditCardDal)
		{
			_creditCardDal = creditCardDal;
		}

		public IDataResult<CreditCard> GetCreditCard(Expression<Func<CreditCard, bool>> filter = null)
		{
			return new SuccessDataResult<CreditCard>(_creditCardDal.Get(filter));
		}

		public IDataResult<List<CreditCard>> GetCreditCards(Expression<Func<CreditCard, bool>> filter = null)
		{
			return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(filter));
		}

		[ValidationAspect(typeof(CreditCardValidator))]
		public IResult Pay(CreditCard creditCard)
		{
			_creditCardDal.Add(creditCard);
			return new SuccessResult();
		}
	}
}
