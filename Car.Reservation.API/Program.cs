using CarReservation.Domain.Data;
using CarReservation.Domain.Interfaces;
using CarReservation.Domain.Services;
using CarReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Car.Reservation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            
            builder.Services.AddDbContext<CarReservationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "CarReservationDatabase"));
            var services = builder.Services;
           
            services.AddDbContext<CarReservationDbContext>();

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IReservationService, ReservationService>();

            builder.Services.AddControllers();

            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car Reservation API", Version = "v1" });
            });

            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Reservation API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
