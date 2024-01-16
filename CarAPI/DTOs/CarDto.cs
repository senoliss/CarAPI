using CarAPI.Models;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;

namespace CarAPI.DTOs
{
	public class CarDto
	{
		/// <summary>
		/// Make or manufacturer of the car (e.g., Toyota, Honda, Ford).
		/// </summary>
		public string Make { get; set; }
		/// <summary>
		/// Model name of the car (e.g., Camry, Civic, Mustang).
		/// </summary>
		public string Model { get; set; }
		/// <summary>
		/// Year the car was manufactured.
		/// </summary>
		public int Year { get; set; }
		/// <summary>
		/// Color of the car.
		/// </summary>
		public string Color { get; set; }
		/// <summary>
		/// Fuel type of the car (e.g. Gasoline, Diesel, Electric)
		/// </summary>
		public string FuelType { get; set; }

        public CarDto()
        {
        }

        public CarDto(Car model)
        {
            Make = model.Make;
			Model = model.Model;
			Year = model.Year;
			Color = model.Color;
			FuelType = model.FuelType;
        }

        public Car ToModel()
        {
            return new Car() { Make = Make, Model = Model, Year = Year, Color = Color, FuelType = FuelType };
        }
    }
}
