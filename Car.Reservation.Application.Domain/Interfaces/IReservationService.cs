using CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation ReserveCar(string carId, DateTime startTime, TimeSpan duration);

    }
}
