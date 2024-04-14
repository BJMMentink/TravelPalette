namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utAddress : utBase<tblAddress> 
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var addresses = base.LoadTest(); 
            Assert.AreEqual(expected, addresses.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblAddress newRow = new tblAddress();

            newRow.StreetName = "XXXXXX";
            newRow.City = "Greenville";
            newRow.State = "WI";
            newRow.ZIP = "54942";

            dc.tblAddresses.Add(newRow);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblAddress row = dc.tblAddresses.FirstOrDefault();

            if (row != null)
            {
                row.StreetName = "Updated Street Name";
                row.City = "Updated City";

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblAddress row = dc.tblAddresses.FirstOrDefault();

            if (row != null)
            {
                dc.tblAddresses.Remove(row);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
