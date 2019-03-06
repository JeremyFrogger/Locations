using Locations.Controllers;
using Locations.Data;
using Locations.Data.Interfaces;
using Locations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Locations.Test
{
    [TestClass]
    public class LocationControllerTests
    {
        [TestMethod]
        public void TestLoctionIndexNoneTypeView()
        {
            // Arrange
            var locations = GetAllLocations();
            var mockLocationService = new Mock<ILocationService>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockLocationService.Setup(r => r.GetAll(LocationType.None)).Returns(locations);
            var controller = new LocationsController(mockLocationService.Object, mockPostCodeService.Object);

            // Act
            var result = controller.Index((int)LocationType.None, null, 1);

            // Assert
            Assert.AreEqual(locations.Count(), ((LocationsIndexViewModel)((ViewResult)result).Model).Locations.Count);
        }

        [TestMethod]
        public void TestLoctionIndexLocalTypeView()
        {
            // Arrange
            var locations = GetAllLocations();
            var mockLocationService = new Mock<ILocationService>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockLocationService.Setup(r => r.GetAll(LocationType.Local)).Returns(locations);
            var controller = new LocationsController(mockLocationService.Object, mockPostCodeService.Object);

            // Act
            var result = controller.Index((int)LocationType.Local, null, 1);

            // Assert
            Assert.AreEqual(locations.Count(), ((LocationsIndexViewModel)((ViewResult)result).Model).Locations.Count);
        }

        [TestMethod]
        public void TestLocationDetailView()
        {
            // Arrange
            var location = GetLocation();
            var mockLocationService = new Mock<ILocationService>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockLocationService.Setup(r => r.GetById(3)).Returns(location);
            var controller = new LocationsController(mockLocationService.Object, mockPostCodeService.Object);

            // Act
            var result = controller.Details(3);

            // Assert
            var locationTypeEx = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)location.Type);
            Assert.AreEqual(location.Name, ((LocationsDetailsViewModel)((ViewResult)result).Model).Name);
            Assert.AreEqual(locationTypeEx, ((LocationsDetailsViewModel)((ViewResult)result).Model).LocationType);
        }

        [TestMethod]
        public void TestLocationCreateView()
        {
            // Arrange
            var location = new Location { Name = "Store test", Type = LocationType.Megastore };
            
            var mockLocationService = new Mock<ILocationService>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockLocationService.Setup(r => r.Add(location));
            var controller = new LocationsController(mockLocationService.Object, mockPostCodeService.Object);

            // Act
            var result = controller.Create(GetViewModel(0));

            // Assert
            var locationTypeEx = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)location.Type);
            Assert.AreEqual(location.Name, ((LocationsDetailsViewModel)((ViewResult)result).Model).Name);
            Assert.AreEqual(locationTypeEx, ((LocationsDetailsViewModel)((ViewResult)result).Model).LocationType);
        }

        [TestMethod]
        public void TestLocationEditView()
        {
            // Arrange            
            var location = GetLocation();
            location.Name = "Store 4";
            var mockLocationService = new Mock<ILocationService>();
            var mockPostCodeService = new Mock<IPostCodeService>();
            mockLocationService.Setup(r => r.GetById(3)).Returns(location);
            mockLocationService.Setup(r => r.Update(location));            
            var controller = new LocationsController(mockLocationService.Object, mockPostCodeService.Object);

            // Act
            var result = controller.Edit(3);

            // Assert
            var locationTypeEx = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)location.Type);
            Assert.AreEqual(location.Name, ((LocationsDetailsViewModel)((ViewResult)result).Model).Name);
            Assert.AreEqual(locationTypeEx, ((LocationsDetailsViewModel)((ViewResult)result).Model).LocationType);
        }

        #region Data

        private IEnumerable<Location> GetAllLocations()
        {
            return new List<Location>
            {
                new Location{ Id = 1, Name="Store 1", Type=LocationType.Local },
                new Location{ Id = 2, Name="Store 2", Type=LocationType.Local },
                new Location{ Id = 3, Name="Store 3", Type=LocationType.Local }
            };
        }

        private Location GetLocation()
        {
            return new Location { Id = 3, Name = "Store 3", Type = LocationType.Local };
        }


        private static LocationsDetailsViewModel GetViewModel(int id)
        {
            return new LocationsDetailsViewModel
            {
                Id = id,
                Name = "Store test",
                LocationType = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)LocationType.Megastore)
            };
        }

        #endregion

    }
}
