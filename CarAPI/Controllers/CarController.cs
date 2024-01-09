using CarAPI.Databases;
using CarAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly ICarRepository _carRepository;

		public CarController(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		/// <summary>
		/// Returns a list of all cars from DB
		/// </summary>
		/// <returns></returns>
		[HttpGet("list")]
		[Produces(MediaTypeNames.Application.Json)]
		public IEnumerable<Car> GetAll()
		{
			var data = _carRepository.GetAllCars();
			return data;
		}

		[HttpGet("color")]
		public ActionResult<Car> GetCarsByColor([FromQuery] string color)
		{
			var carsByColor = _carRepository.GetCarsByColor(color);
			if(carsByColor == null)
			{
				return NotFound();
			}
			return Ok(carsByColor);
		}
	}
}
