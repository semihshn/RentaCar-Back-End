using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreditCardsController : Controller
	{

		ICreditCardService _creditCardService;

		public CreditCardsController(ICreditCardService creditCardService)
		{
			_creditCardService = creditCardService;
		}

		[HttpPost("pay")]
		public IActionResult Add(CreditCard creditCard)
		{
			var result = _creditCardService.Pay(creditCard);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _creditCardService.GetCreditCards();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
