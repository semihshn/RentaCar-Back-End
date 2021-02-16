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
    public class CarModelsController : ControllerBase
    {
        ICarModelService _carModelService;

        public CarModelsController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carModelService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carModelService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CarModel carModel)
        {
            var result = _carModelService.Add(carModel);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(CarModel carModel)
        {
            var result = _carModelService.Update(carModel);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarModel carModel)
        {
            var result = _carModelService.Delete(carModel);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
