namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var users = base.LoadTest();
            Assert.AreEqual(expected, users.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newUser = new tblUser
            {
                Username = "testuser",
                Password = "password",
                Email = "test@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            dc.tblUsers.Add(newUser);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUser user = dc.tblUsers.FirstOrDefault();

            if (user != null)
            {
                user.Username = "updateduser";
                user.Password = "updatedpassword";
                user.Email = "updated@example.com";
                user.FirstName = "Jane";
                user.LastName = "Doe";

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblUser user = dc.tblUsers.FirstOrDefault();

            if (user != null)
            {
                dc.tblUsers.Remove(user);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
