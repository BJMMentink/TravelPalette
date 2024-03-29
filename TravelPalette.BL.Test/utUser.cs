using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utUser
    {
        //bmb added tests
        [TestMethod]
        public void LoginSuccessfulTest()
        {
            Seed();
            Assert.IsTrue(UserManager.Login(new User { Username = "john_doe", Password = "password123" }));
            Assert.IsTrue(UserManager.Login(new User { Username = "jane_smith", Password = "letmein" }));
            Assert.IsTrue(UserManager.Login(new User { Username = "bob_johnson", Password = "securepassword" }));
        }

        public void Seed()
        {
            UserManager.Seed();
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(6, UserManager.Load().Count);
        }

        [TestMethod]
        public void InsertTest()
        //bmb updated
        {
            int id = 0;
            // Arrange
            User user = new User
            {
                Username = "testuser",
                Password = "testpassword",
                Email = "test@example.com",
                FirstName = "Test",
                LastName = "User"
            };

            // Act
            int results = UserManager.Insert(user, true);
            // Assert
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoginFailureNoUsername()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { Username = "", Password = "password123" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureBadPassword()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { Username = "john_doe", Password = "food" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureBadUserName()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { Username = "johndoe", Password = "password123" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureNoPassword()
        {
            try
            {
                Seed();
                Assert.IsFalse(UserManager.Login(new User { Username = "john_doe", Password = "" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
             //Arrange
            var userId = 2;
            var updatedLastName = "UpdatedLastName";

           // Act
            var user = UserManager.LoadById(userId);
            user.LastName = updatedLastName;
            var result = UserManager.Update(user, true);

            //Assert
            Assert.AreEqual(1, result);
        }
    }
}
