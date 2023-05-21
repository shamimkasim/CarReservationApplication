using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using CarReservation.Infrastructure.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Infrastructure.Persistence
{

    public static class InMemoryDatabase
    {
        public static ConcurrentDictionary<string, Car> Cars { get; } = new ConcurrentDictionary<string, Car>();
        public static ConcurrentDictionary<string, Reservation> Reservations { get; } = new ConcurrentDictionary<string, Reservation>();
    }
}
