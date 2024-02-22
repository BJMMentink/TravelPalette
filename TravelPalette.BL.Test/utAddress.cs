using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.TextTemplating;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utAddress
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, AddressManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Address Address = AddressManager.LoadById(1);
            Assert.IsNotNull(Address);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Address Address = new Address
            {
                Id = id,
                StreetName = "2244 Aurthur Avenue",
                City = "Arlington",
                ZIP = "23454",
                State = "NJ"
            };

            int results = AddressManager.Insert(Address, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Address address = AddressManager.LoadById(2);
            address.StreetName = "2244 Aurthur Avenue";
            address.City = "Arlington";
            address.ZIP = "23454";
            address.State = "NJ";

            int results = AddressManager.Update(address, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = AddressManager.Delete(1, true);
            Assert.AreEqual(1, results);
        }
    }
}
