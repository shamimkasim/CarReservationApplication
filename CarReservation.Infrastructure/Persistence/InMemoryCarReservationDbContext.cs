using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Infrastructure.Persistence
{
    public class InMemoryCarReservationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public InMemoryCarReservationDbContext(DbContextOptions<InMemoryCarReservationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(c => c.Id)
                    .IsRequired();

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Reserved)
                    .IsRequired();

                entity.HasOne(c => c.Reservation)
                    .WithOne(r => r.Car)
                    .HasForeignKey<Reservation>(r => r.CarId);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(r => r.Id)
                    .IsRequired();

                entity.Property(r => r.StartTime)
                    .IsRequired();

                entity.Property(r => r.Duration)
                    .IsRequired();
            });
        }
    }
}
