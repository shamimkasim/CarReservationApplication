using CarReservation.API.Controllers;
using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarReservation.Tests.UnitTests
{
    public class CarsControllerTests
    {
        [TestMethod]
        public void AddCar_ReturnsOkResult()
        {
            // Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            var controller = new CarsController(carRepositoryMock.Object);
            var car = new CarReservation.Domain.Entities.Car { Make = "Toyota", Model = "Camry" };

            // Act
            var result = controller.AddCar(car);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void UpdateCar_ReturnsOkResult()
        {
            // Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            var controller = new CarsController(carRepositoryMock.Object);
            var carId = "C1";
            var updatedCar = new CarReservation.Domain.Entities.Car { Make = "Honda", Model = "Accord" };

            // Act
            var result = controller.UpdateCar(carId, updatedCar);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteCar_ReturnsOkResult()
        {
            // Arrange
            var carRepositoryMock = new Mock<ICarRepository>();
            var controller = new CarsController(carRepositoryMock.Object);
            var carId = "C1";

            // Act
            var result = controller.DeleteCar(carId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

    }    
}

