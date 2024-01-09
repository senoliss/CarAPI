namespace CarAPI.Models
{
	public class Car
	{
        /// <summary>
        /// Unique identifier for the car.
        /// </summary>
        public int Id { get; set; }

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
    }
}
