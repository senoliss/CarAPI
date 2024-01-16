using CarAPI.DTOs;
using CarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Databases
{
	public interface ICarRepository
	{
		void AddNewCar(Car car);
		List<Car> GetAllCars();
		IEnumerable<Car> GetCarsByColor(string color);
		void RemoveCar(int id);
		void UpdateCar(Car car);
	}
	public class CarRepository : ICarRepository
	{
		private readonly CarsDbContext _carsDbContext;
		//private readonly ILogger _logger;
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

		public void AddNewCar(Car car)
		{
			_carsDbContext.Cars.Add(car);
            _carsDbContext.SaveChanges();
		}

        public void UpdateCar(Car car)
        {
            var carFromDb = _carsDbContext.Cars.FirstOrDefault(c => car.Id == c.Id);

            if (carFromDb == null)
            {
                //_logger.LogError($"Book with ID {car.Id} was not found in database");
                throw new ArgumentException($"Book with ID {car.Id} was not found in database");
            }

            if (!string.IsNullOrEmpty(car.Make))
            {
                carFromDb.Make = car.Make;
            }
            if (!string.IsNullOrEmpty(car.Model))
            {
                carFromDb.Model = car.Model;
            }
            if (car.Year > 0)
            {
                carFromDb.Year = car.Year;
            }
            if (!string.IsNullOrEmpty(car.Color))
            {
                carFromDb.Color = car.Color;
            }
            if (!string.IsNullOrEmpty(car.FuelType))
            {
                carFromDb.FuelType = car.FuelType;
            }
            _carsDbContext.SaveChanges();

        }

        public void RemoveCar(int id)
        {
            var carFromDb = _carsDbContext.Cars.FirstOrDefault(c => c.Id == id);
            _carsDbContext.Cars.Remove(carFromDb);
            _carsDbContext.SaveChanges();
        }
    }
}
