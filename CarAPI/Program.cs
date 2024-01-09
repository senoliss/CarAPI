
using CarAPI.Databases;
using Microsoft.EntityFrameworkCore;

namespace CarAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//Dependancy Injection (DI, IoC) configuration
			builder.Services.AddScoped<ICarRepository, CarRepository>();
			builder.Services.AddDbContext<CarsDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
			});
			// DI config end

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
