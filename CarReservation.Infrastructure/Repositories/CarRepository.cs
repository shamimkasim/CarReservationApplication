using CarReservation.Domain.Data;
using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarReservationDbContext _dbContext;
        private DbSet<Car> _cars;


        public CarRepository(CarReservationDbContext dbContext)
        {
            _dbContext = dbContext;
            _cars = _dbContext.Set<Car>();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public Car GetById(string id)
        {
            return _cars.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("Car not found"); ;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            // No specific implementation for in-memory database
        }

        public void Delete(Car car)
        {
            _cars.Remove(car);
        }

        public Car GetCarById(string carId)
        {
            return _cars.FirstOrDefault(c => c.Id == carId);
        }
    }
}
