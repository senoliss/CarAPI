using CarAPI.DTOs;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Databases
{
	public interface ICarRepository
	{
		List<Car> GetAllCars();
		IEnumerable<Car> GetCarsByColor(string color);
	}
	public class CarRepository : ICarRepository
	{
		private readonly CarsDbContext _carsDbContext;
		public CarRepository() { }

        public CarRepository(CarsDbContext carsDbContext)
        {
			_carsDbContext = carsDbContext;

		}

        public List<Car> GetAllCars()
		{
			return _carsDbContext.Cars.ToList();
		}

		public IEnumerable<Car> GetCarsByColor(string color)
		{
			return _carsDbContext.Cars.Where(c => c.Color == color).ToList();
		}

		public void AddNewCar(CarDto car)
		{
			_carsDbContext.Cars.Add(car);
		}
	}
}
