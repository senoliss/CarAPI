using CarAPI.Models;

namespace CarAPI.DTOs
{
	public class CarMakerDto
	{
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }



        public CarMakerDto(Car model)
        {
            Id = model.Id;
            Make = model.Make;
            Model = model.Model;

        }

        public CarMakerDto()
        {
        }

        public Car ToModel()
        {
            return new Car() { Id = Id, Make = Make, Model = Model };
        }
    }
}
