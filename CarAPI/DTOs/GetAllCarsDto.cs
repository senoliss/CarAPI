using CarAPI.Models;

namespace CarAPI.DTOs
{
	public class GetAllCarsDto
	{
        public GetAllCarsDto(Car model)
        {
            Id = model.Id;
            Make = model.Make;
            Model = model.Model;
            Year = model.Year;
            Color = model.Color;
            FuelType = model.FuelType;
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
    }
}
