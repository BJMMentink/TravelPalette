using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utLocationTag
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, LocationTagManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            LocationTag locationTag = LocationTagManager.LoadById(1);
            Assert.IsNotNull(locationTag);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            LocationTag locationTag = new LocationTag
            {
                Id = id,
                LocationId = 1,
                TagId = 1
            };

            int results = LocationTagManager.Insert(locationTag, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            LocationTag locationTag = LocationTagManager.LoadById(2);
            locationTag.LocationId = 2;
            locationTag.TagId = 2;

            int results = LocationTagManager.Update(locationTag, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = LocationTagManager.Delete(1, true);
            Assert.AreEqual(1, results);
        }
    }
}
