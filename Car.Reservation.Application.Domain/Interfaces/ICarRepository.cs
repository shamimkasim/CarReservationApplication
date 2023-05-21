using CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Domain.Interfaces
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car GetCarById(string carId);
        Car GetById(string id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
