using CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Domain.Data
{
    public class CarReservationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public CarReservationDbContext(DbContextOptions<CarReservationDbContext> options)
            : base(options)
        {
        }
    }
}
