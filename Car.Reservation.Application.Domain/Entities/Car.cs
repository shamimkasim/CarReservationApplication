using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Domain.Entities
{
    public class Car
    {       
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public bool Reserved { get; set; }

        public Reservation Reservation { get; set; }
    }
}
