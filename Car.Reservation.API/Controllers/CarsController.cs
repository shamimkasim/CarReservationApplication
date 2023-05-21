using CarReservation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CarReservation.Domain.Entities;

namespace CarReservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = _carRepository.GetAll();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar(CarReservation.Domain.Entities.Car car)
        {
            if (car == null)
            {
                return BadRequest("Invalid car data.");
            }

            if (!ValidateCar(car))
            {
                return BadRequest("Invalid car details.");
            }

            _carRepository.Add(car);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(string id, CarReservation.Domain.Entities.Car updatedCar)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid car ID.");
            }

            var car = _carRepository.GetById(id);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            if (!ValidateCar(updatedCar))
            {
                return BadRequest("Invalid car details.");
            }

            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;

            _carRepository.Update(car);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid car ID.");
            }

            var car = _carRepository.GetById(id);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            _carRepository.Delete(car);

            return Ok();
        }

        private bool ValidateCar(CarReservation.Domain.Entities.Car car)
        {
            if (string.IsNullOrEmpty(car.Make) || string.IsNullOrEmpty(car.Model))
            {
                return false;
            }           

            return true;
        }
    }
}
