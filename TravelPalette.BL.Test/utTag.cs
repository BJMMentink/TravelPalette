using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utTag
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, TagManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Tag tag = new Tag
            {
                Id = id,
                Description = "Test",
            };

            int results = TagManager.Insert(tag, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Tag tag = TagManager.LoadById(1);
            tag.Description = "Test";

            int results = TagManager.Update(tag, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int results = TagManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

    }
}