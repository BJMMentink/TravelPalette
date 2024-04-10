using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelPalette.BL.Models;

namespace TravelPalette.BL.Test
{
    [TestClass]
    public class utSchedule
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(2, ScheduleManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Schedule schedule = ScheduleManager.LoadById(1);
            Assert.IsNotNull(schedule);
        }

        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Schedule schedule = new Schedule
            {
                Id = id,
                LocationId = 1,
                MondayOpen = new TimeOnly(8, 0),
                MondayClose = new TimeOnly(17, 0),
                // Similarly initialize other properties as per your requirement
            };

            int results = ScheduleManager.Insert(schedule, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Schedule schedule = ScheduleManager.LoadById(1);
            schedule.MondayOpen = new TimeOnly(9, 0);
            schedule.MondayClose = new TimeOnly(18, 0);
            // Similarly update other properties as per your requirement

            int results = ScheduleManager.Update(schedule, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = ScheduleManager.Delete(1, true);
            Assert.AreEqual(1, results);
        }
    }
}
