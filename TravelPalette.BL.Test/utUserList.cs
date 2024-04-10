using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utUserList
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, UserListManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            UserList userList = UserListManager.LoadById(1);
            Assert.IsNotNull(userList);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            UserList userList = new UserList
            {
                Id = id,
                UserId = 1,
                ListId = 1,
                ListName = "Test List"
            };

            int results = UserListManager.Insert(userList, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            UserList userList = UserListManager.LoadById(2);
            userList.ListName = "Updated List Name";

            int results = UserListManager.Update(userList, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = UserListManager.Delete(1, true);
            Assert.AreEqual(1, results);
        }
    }
}
