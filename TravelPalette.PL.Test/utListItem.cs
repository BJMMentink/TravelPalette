namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utListItem : utBase<tblListItem>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var items = base.LoadTest();
            Assert.AreEqual(expected, items.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblListItem newItem = new tblListItem();

            newItem.LocationId = 1; 

            dc.tblListItems.Add(newItem);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblListItem item = dc.tblListItems.FirstOrDefault();

            if (item != null)
            {
                item.LocationId = 2;

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblListItem item = dc.tblListItems.FirstOrDefault();

            if (item != null)
            {
                dc.tblListItems.Remove(item);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
