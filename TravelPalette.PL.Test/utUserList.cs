namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utUserList : utBase<tblUserList>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var userLists = base.LoadTest();
            Assert.AreEqual(expected, userLists.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUserList newUserList = new tblUserList
            {
                UserId = 1,
                ListId = 1,
                ListName = "Test List"
            };

            dc.tblUserLists.Add(newUserList);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUserList userList = dc.tblUserLists.FirstOrDefault();

            if (userList != null)
            {
                userList.ListName = "Updated List Name";

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblUserList userList = dc.tblUserLists.FirstOrDefault();

            if (userList != null)
            {
                dc.tblUserLists.Remove(userList);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
