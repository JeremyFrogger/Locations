using Locations.Data;
using Locations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Locations.Test
{
    [TestClass]
    public class LocationServicesTests
    {
        [TestMethod]
        public void AddTest()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Location>>();
            var mockContext = new Mock<LocationsContext>();

            // Act
            mockContext.Setup(c => c.Locations).Returns(mockDbSet.Object);
            var service = new LocationService(mockContext.Object);

            service.Add(new Location());

            // Assert
            mockContext.Verify(s => s.Add(It.IsAny<Location>()), Times.Once());
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAllTypeNoneTest()
        {
            // Arrange
            var locations = new List<Location>
            {
                new Location
                {
                    Name = "Location 1",
                    Type = LocationType.Local,
                    Id = 1
                },

                new Location
                {
                    Name = "Location 2",
                    Type = LocationType.Megastore,
                    Id = 2
                }
            }.AsQueryable();

            // Act
            var mockDbSet = new Mock<DbSet<Location>>();
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Provider).Returns(locations.Provider);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Expression).Returns(locations.Expression);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.ElementType).Returns(locations.ElementType);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.GetEnumerator()).Returns(locations.GetEnumerator);

            var mockContext = new Mock<LocationsContext>();
            mockContext.Setup(c => c.Locations).Returns(mockDbSet.Object);

            var service = new LocationService(mockContext.Object);
            var result = service.GetAll(LocationType.None).ToList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Location>));
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(locations.ToList()[0].Name, result[0].Name);
            Assert.AreEqual(locations.ToList()[1].Name, result[1].Name);
        }

        [TestMethod]
        public void GetAllTypeLocalTest()
        {
            // Arrange
            var locations = new List<Location>
            {
                new Location
                {
                    Name = "Location 1",
                    Type = LocationType.Local,
                    Id = 1
                },

                new Location
                {
                    Name = "Location 2",
                    Type = LocationType.Megastore,
                    Id = 2
                }
            }.AsQueryable();

            // Act
            var mockDbSet = new Mock<DbSet<Location>>();
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Provider).Returns(locations.Provider);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Expression).Returns(locations.Expression);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.ElementType).Returns(locations.ElementType);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.GetEnumerator()).Returns(locations.GetEnumerator);

            var mockContext = new Mock<LocationsContext>();
            mockContext.Setup(c => c.Locations).Returns(mockDbSet.Object);

            var service = new LocationService(mockContext.Object);
            var result = service.GetAll(LocationType.Local).ToList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Location>));
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(locations.ToList()[0].Name, result[0].Name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            // Arrange
            var locations = new List<Location>
            {
                new Location
                {
                    Name = "Location 1",
                    Id = 1
                },

                new Location
                {
                    Name = "Location 2",
                    Id = 2
                }
            }.AsQueryable();

            // Act
            var mockDbSet = new Mock<DbSet<Location>>();
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Provider).Returns(locations.Provider);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.Expression).Returns(locations.Expression);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.ElementType).Returns(locations.ElementType);
            mockDbSet.As<IQueryable<Location>>().Setup(b => b.GetEnumerator()).Returns(locations.GetEnumerator);

            var mockContext = new Mock<LocationsContext>();
            mockContext.Setup(c => c.Locations).Returns(mockDbSet.Object);

            var service = new LocationService(mockContext.Object);
            var location = service.GetById(2);

            // Assert
            Assert.AreEqual(locations.ToList()[1].Name, location.Name);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            var location = new Location
            {
                Name = "Location 1",
                Id = 1
            };
            var mockDbSet = new Mock<DbSet<Location>>();
            var mockContext = new Mock<LocationsContext>();

            // Act
            mockContext.Setup(c => c.Locations).Returns(mockDbSet.Object);
            var service = new LocationService(mockContext.Object);

            service.Update(location);

            // Assert            
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
