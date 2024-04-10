using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utLocation
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, LocationManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Location location = LocationManager.LoadById(1);
            Assert.IsNotNull(location);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Location location = new Location
            {
                Id = id,
                AddressId = 99, // Test integer value
                Description = "Test",
                BusinessName = "Test",
                Coordinates = "Test",
                PhoneNumber = "Test"
            };

            int results = LocationManager.Insert(location, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Location location = LocationManager.LoadById(2);
            location.Description = "Test";

            int results = LocationManager.Update(location, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = LocationManager.Delete(1, true);
            Assert.AreEqual(1, results);
        }
    }
}
