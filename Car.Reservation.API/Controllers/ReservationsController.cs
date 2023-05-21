using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarReservation.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationService reservationService, IReservationRepository reservationRepository)
        {
            _reservationService = reservationService;
            _reservationRepository = reservationRepository;
        }

        [HttpPost]
        public IActionResult ReserveCar(ReservationRequest request)
        {
            try
            {
                var reservation = _reservationService.ReserveCar(request.CarId, request.StartTime, request.Duration);
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUpcomingReservations()
        {
            List<Reservation> reservations = _reservationRepository.GetUpcomingReservations();
            return Ok(reservations);
        }

        public class ReservationRequest
        {
            public string CarId { get; set; }
            public DateTime StartTime { get; set; }
            public TimeSpan Duration { get; set; }
        }
    }
}
