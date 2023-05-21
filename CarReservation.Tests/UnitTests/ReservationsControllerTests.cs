using CarReservation.API.Controllers;
using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
namespace CarReservation.Tests.UnitTests
{
    [TestClass]
    public class ReservationsControllerTests
    {
        [TestMethod]
        public void ReserveCar_ValidRequest_ReturnsOkResult()
        {            // Arrange
            var reservationServiceMock = new Mock<IReservationService>();
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var controller = new ReservationsController(reservationServiceMock.Object, reservationRepositoryMock.Object);
            var request = new ReservationsController.ReservationRequest
            {
                CarId = "C1",
                StartTime = DateTime.Now,
                Duration = TimeSpan.FromHours(2)
            };
            var reservation = new Reservation();

            reservationServiceMock.Setup(s => s.ReserveCar(request.CarId, request.StartTime, request.Duration)).Returns(reservation);

            // Act
            var result = controller.ReserveCar(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(reservation, okResult.Value);
        }

        [TestMethod]
        public void GetUpcomingReservations_ReturnsOkResultWithReservations()
        {
            // Arrange
            var reservationServiceMock = new Mock<IReservationService>();
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var controller = new ReservationsController(reservationServiceMock.Object, reservationRepositoryMock.Object);
            var reservations = new List<Reservation> { new Reservation(), new Reservation() };

            reservationRepositoryMock.Setup(r => r.GetUpcomingReservations()).Returns(reservations);

            // Act
            var result = controller.GetUpcomingReservations();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(reservations, okResult.Value);
        }
    }
}
