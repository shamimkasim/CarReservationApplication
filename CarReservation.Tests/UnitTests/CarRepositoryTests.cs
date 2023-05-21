using CarReservation.Domain.Entities;
using CarReservation.Domain.Interfaces;
using CarReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarReservation.Tests.UnitTests
{
    public class CarRepositoryTests
    {
        [Fact]
        public void GetCarById_Returns_Car_When_Found()
        {
            // Arrange
            var cars = new List<CarReservation.Domain.Entities.Car>
            {
                new CarReservation.Domain.Entities.Car { Id = "C1", Make = "Toyota", Model = "Camry" },
                new CarReservation.Domain.Entities.Car { Id = "C2", Make = "Honda", Model = "Accord" },
            };

            var dbContextMock = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<CarReservation.Domain.Entities.Car>>();
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.Provider).Returns(cars.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.Expression).Returns(cars.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.ElementType).Returns(cars.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.GetEnumerator()).Returns(cars.AsQueryable().GetEnumerator());

            dbContextMock.Setup(db => db.Set<CarReservation.Domain.Entities.Car>()).Returns(dbSetMock.Object);

            var carRepository = new CarRepository(dbContextMock.Object);

            // Act
            var car = carRepository.GetCarById("C1");

            // Assert
            Assert.NotNull(car);
            Assert.Equals("C1", car.Id);
            Assert.Equals("Toyota", car.Make);
            Assert.Equals("Camry", car.Model);
        }

        [Fact]
        public void GetCarById_Returns_Null_When_CarNotFound()
        {
            // Arrange
            var cars = new List<CarReservation.Domain.Entities.Car>
            {
                new CarReservation.Domain.Entities.Car { Id = "C1", Make = "Toyota", Model = "Camry" },
                new CarReservation.Domain.Entities.Car { Id = "C2", Make = "Honda", Model = "Accord" },
            };

            var dbContextMock = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<CarReservation.Domain.Entities.Car>>();
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.Provider).Returns(cars.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.Expression).Returns(cars.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.ElementType).Returns(cars.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CarReservation.Domain.Entities.Car>>().Setup(m => m.GetEnumerator()).Returns(cars.AsQueryable().GetEnumerator());

            dbContextMock.Setup(db => db.Set<CarReservation.Domain.Entities.Car>()).Returns(dbSetMock.Object);

            var carRepository = new CarRepository(dbContextMock.Object);

            // Act
            var car = carRepository.GetCarById("C3");

            // Assert
            Assert.Null(car);
        }
    }
}

