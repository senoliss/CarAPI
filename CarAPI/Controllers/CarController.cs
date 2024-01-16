using CarAPI.Databases;
using CarAPI.DTOs;
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
		/// <returns>belekas</returns>
		[HttpGet("list")]
		[Produces(MediaTypeNames.Application.Json)]		// Defines in swagger interface what media type is returned.
		public IEnumerable<Car> GetAll()
		{
			var data = _carRepository.GetAllCars();
			return data;
		}

		[HttpGet("GetCarById{id}")]
		[Produces(MediaTypeNames.Application.Json)]
		public ActionResult<Car> GetSingleCar(int id)
		{
			var carById = _carRepository.GetAllCars().Find(c => c.Id == id);
			if(carById == null)
			{
				return NotFound();
			}
			return Ok(carById);
		}

		[HttpGet("color")]
		[Produces(MediaTypeNames.Application.Json)]
		public ActionResult<Car> GetCarsByColor([FromQuery] string color)
		{
			var carsByColor = _carRepository.GetCarsByColor(color);
			if (carsByColor == null)
			{
				return NotFound();
			}
			return Ok(carsByColor);
		}

		[HttpPost]
		[Produces(MediaTypeNames.Application.Json)]
		public Car AddNewCar(CarDto car)
		{
			Car carModel = car.ToModel();           // constructs a Car object from CarDto
			_carRepository.AddNewCar(carModel);     // sends the Car to repository
			return carModel;
		}

		[HttpPut("UpdateCarMakeAndModel")]
		[Produces(MediaTypeNames.Application.Json)]
		public void UpdateCar(CarMakerDto carMaker)
		{
			Car carModel = carMaker.ToModel();          // constructs a Car object from CarDto
			_carRepository.UpdateCar(carModel);     // sends the Car to repository
		}

		[HttpDelete("RemoveCarById{id}")]
		[Produces(MediaTypeNames.Application.Json)]
		public void RemoveCar(int id)
		{
			_carRepository.RemoveCar(id);
		}
	}
}
