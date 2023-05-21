using CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Reservation AddReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        List<Reservation> GetUpcomingReservations();
    }
}
