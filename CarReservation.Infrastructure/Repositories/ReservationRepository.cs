using CarReservation.Domain.Data;
using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarReservationDbContext _dbContext;       

        private List<Reservation> _reservations;

        public ReservationRepository(CarReservationDbContext dbContext)
        {
            _reservations = new List<Reservation>();
            _dbContext = dbContext;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
            return reservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public List<Reservation> GetUpcomingReservations()
        {
            return _reservations.Where(r => r.StartTime >= DateTime.UtcNow).ToList();
        }
    }
}
