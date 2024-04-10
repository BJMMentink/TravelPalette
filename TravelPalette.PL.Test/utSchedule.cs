namespace TravelPalette.PL.Test
{
    [TestClass]
    public class utSchedule : utBase<tblSchedule>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 2;
            var schedules = base.LoadTest();
            Assert.AreEqual(expected, schedules.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblSchedule newSchedule = new tblSchedule();

            newSchedule.LocationId = 1; 
            newSchedule.MondayOpen = null; 
            newSchedule.MondayClose = null;
            newSchedule.TuesdayOpen = null;
            newSchedule.TuesdayClose = null;
            newSchedule.WednesdayOpen = null;
            newSchedule.WednesdayClose = null;
            newSchedule.ThursdayOpen = null;
            newSchedule.ThursdayClose = null;
            newSchedule.FridayOpen = null;
            newSchedule.FridayClose = null;
            newSchedule.SaturdayOpen = null;
            newSchedule.SaturdayClose = null;
            newSchedule.SundayOpen = null;
            newSchedule.SundayClose = null;



            dc.tblSchedules.Add(newSchedule);

            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblSchedule schedule = dc.tblSchedules.FirstOrDefault();

            if (schedule != null)
            {
                schedule.MondayOpen = null; 
                schedule.MondayClose = null; 

                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblSchedule schedule = dc.tblSchedules.FirstOrDefault();

            if (schedule != null)
            {
                dc.tblSchedules.Remove(schedule);

                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
