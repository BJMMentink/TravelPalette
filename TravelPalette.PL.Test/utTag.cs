namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utTag : utBase<tblTag>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3; 
            var tags = base.LoadTest(); 
            Assert.AreEqual(expected, tags.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblTag newTag = new tblTag
            {
                Description = "Test Description"
            };

            dc.tblTags.Add(newTag);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblTag tag = dc.tblTags.FirstOrDefault();

            if (tag != null)
            {
                tag.Description = "Updated Description";

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblTag tag = dc.tblTags.FirstOrDefault();

            if (tag != null)
            {
                dc.tblTags.Remove(tag);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
