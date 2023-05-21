using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ICarRepository _carRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(ICarRepository carRepository, IReservationRepository reservationRepository)
        {
            _carRepository = carRepository;
            _reservationRepository = reservationRepository;
        }

        public Reservation ReserveCar(string carId, DateTime startTime, TimeSpan duration)
        {
            var car = _carRepository.GetCarById(carId);
            if (car == null)
            {
                throw new Exception("Car not found.");
            }

            if (startTime < DateTime.UtcNow || startTime > DateTime.UtcNow.AddHours(24))
            {
                throw new Exception("Invalid reservation start time.");
            }

            if (duration <= TimeSpan.Zero || duration > TimeSpan.FromHours(2))
            {
                throw new Exception("Invalid reservation duration.");
            }

            var existingReservation = _reservationRepository.GetAllReservations()
                .FirstOrDefault(r => r.Car.Id == carId && IsOverlapping(r.StartTime, r.Duration, startTime, duration));

            if (existingReservation != null)
            {
                throw new Exception("Car is already reserved for the specified time.");
            }

            var reservation = new Reservation
            {
                Id = GenerateReservationId(),
                Car = car,
                StartTime = startTime,
                Duration = duration
            };

            _reservationRepository.AddReservation(reservation);

            return reservation;
        }

        private bool IsOverlapping(DateTime start1, TimeSpan duration1, DateTime start2, TimeSpan duration2)
        {
            var end1 = start1 + duration1;
            var end2 = start2 + duration2;

            return (start1 <= start2 && start2 < end1) || (start2 <= start1 && start1 < end2);
        }

        private string GenerateReservationId()
        {
            
            return "R" + Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
