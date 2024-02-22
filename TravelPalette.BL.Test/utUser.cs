using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            var expectedCount = 3;

            // Act
            var userList = UserManager.Load();

            // Assert
            Assert.AreEqual(expectedCount, userList.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            // Arrange
            var userId = 1;

            // Act
            var user = UserManager.LoadById(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.Id);
        }

        [TestMethod]
        public void InsertTest()
        {
            // Arrange
            var user = new User
            {
                Id = 0,
                Username = "testuser",
                Password = "testpassword",
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            // Act
            var result = UserManager.Insert(user, true);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            var userId = 2;
            var updatedLastName = "UpdatedLastName";

            // Act
            var user = UserManager.LoadById(userId);
            user.LastName = updatedLastName;
            var result = UserManager.Update(user, true);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            var userId = 1;

            // Act
            var result = UserManager.Delete(userId, true);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
