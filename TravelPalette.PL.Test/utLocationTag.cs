namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utLocationTag : utBase<tblLocationTag>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var locationTags = base.LoadTest();
            Assert.AreEqual(expected, locationTags.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblLocationTag newLocationTag = new tblLocationTag();

            newLocationTag.LocationId = 1; // Provide a valid LocationId
            newLocationTag.TagId = 1; // Provide a valid TagId

            dc.tblLocationTags.Add(newLocationTag);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblLocationTag locationTag = dc.tblLocationTags.FirstOrDefault();

            if (locationTag != null)
            {
                locationTag.LocationId = 2; // Provide a new LocationId
                locationTag.TagId = 2; // Provide a new TagId

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblLocationTag locationTag = dc.tblLocationTags.FirstOrDefault();

            if (locationTag != null)
            {
                dc.tblLocationTags.Remove(locationTag);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
