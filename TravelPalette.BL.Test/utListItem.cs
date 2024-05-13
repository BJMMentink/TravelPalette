using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utListItem
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, ListItemManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            ListItem listItem = ListItemManager.LoadById(1);
            Assert.IsNotNull(listItem);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            ListItem listItem = new ListItem
            {
                Id = id,
                LocationId = "400"
            };

            int results = ListItemManager.Insert(listItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ListItem listItem = ListItemManager.LoadById(2);
            listItem.LocationId = "500";

            int results = ListItemManager.Update(listItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {

            int results = ListItemManager.Delete(1, "locationId" ,true);
            Assert.AreEqual(1, results);
        }
    }
}
