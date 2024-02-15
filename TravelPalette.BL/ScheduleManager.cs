using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public class ScheduleManager
    {
        public static int Insert(Schedule schedule, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblSchedule entity = new tblSchedule();

                    entity.Id = dc.tblSchedules.Any() ? dc.tblSchedules.Max(s => s.Id) + 1 : 1;
                    entity.LocationId = schedule.LocationId;
                    entity.MondayOpen = schedule.MondayOpen;
                    entity.MondayClose = schedule.MondayClose;
                    entity.TuesdayOpen = schedule.TuesdayOpen;
                    entity.TuesdayClose = schedule.TuesdayClose;
                    entity.WednesdayOpen = schedule.WednesdayOpen;
                    entity.WednesdayClose = schedule.WednesdayClose;
                    entity.ThursdayOpen = schedule.ThursdayOpen;
                    entity.ThursdayClose = schedule.ThursdayClose;
                    entity.FridayOpen = schedule.FridayOpen;
                    entity.FridayClose = schedule.FridayClose;
                    entity.SaturdayOpen = schedule.SaturdayOpen;
                    entity.SaturdayClose = schedule.SaturdayClose;
                    entity.SundayOpen = schedule.SundayOpen;
                    entity.SundayClose = schedule.SundayClose;

                    dc.tblSchedules.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Update(Schedule schedule, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblSchedule entity = dc.tblSchedules.FirstOrDefault(s => s.Id == schedule.Id);

                    if (entity != null)
                    {
                        entity.LocationId = schedule.LocationId;
                        entity.MondayOpen = schedule.MondayOpen;
                        entity.MondayClose = schedule.MondayClose;
                        entity.TuesdayOpen = schedule.TuesdayOpen;
                        entity.TuesdayClose = schedule.TuesdayClose;
                        entity.WednesdayOpen = schedule.WednesdayOpen;
                        entity.WednesdayClose = schedule.WednesdayClose;
                        entity.ThursdayOpen = schedule.ThursdayOpen;
                        entity.ThursdayClose = schedule.ThursdayClose;
                        entity.FridayOpen = schedule.FridayOpen;
                        entity.FridayClose = schedule.FridayClose;
                        entity.SaturdayOpen = schedule.SaturdayOpen;
                        entity.SaturdayClose = schedule.SaturdayClose;
                        entity.SundayOpen = schedule.SundayOpen;
                        entity.SundayClose = schedule.SundayClose;

                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Delete(int Id, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblSchedule entity = dc.tblSchedules.FirstOrDefault(s => s.Id == Id);

                    if (entity != null)
                    {
                        dc.tblSchedules.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Schedule> Load()
        {
            try
            {
                List<Schedule> list = new List<Schedule>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from s in dc.tblSchedules
                     select new
                     {
                         s.Id,
                         s.LocationId,
                         s.MondayOpen,
                         s.MondayClose,
                         s.TuesdayOpen,
                         s.TuesdayClose,
                         s.WednesdayOpen,
                         s.WednesdayClose,
                         s.ThursdayOpen,
                         s.ThursdayClose,
                         s.FridayOpen,
                         s.FridayClose,
                         s.SaturdayOpen,
                         s.SaturdayClose,
                         s.SundayOpen,
                         s.SundayClose
                     })
                     .ToList()
                     .ForEach(schedule => list.Add(new Schedule
                     {
                         Id = schedule.Id,
                         LocationId = schedule.LocationId,
                         MondayOpen = schedule.MondayOpen,
                         MondayClose = schedule.MondayClose,
                         TuesdayOpen = schedule.TuesdayOpen,
                         TuesdayClose = schedule.TuesdayClose,
                         WednesdayOpen = schedule.WednesdayOpen,
                         WednesdayClose = schedule.WednesdayClose,
                         ThursdayOpen = schedule.ThursdayOpen,
                         ThursdayClose = schedule.ThursdayClose,
                         FridayOpen = schedule.FridayOpen,
                         FridayClose = schedule.FridayClose,
                         SaturdayOpen = schedule.SaturdayOpen,
                         SaturdayClose = schedule.SaturdayClose,
                         SundayOpen = schedule.SundayOpen,
                         SundayClose = schedule.SundayClose
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Schedule LoadById(int id)
        {
            try
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblSchedule entity = dc.tblSchedules.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Schedule
                        {
                            Id = entity.Id,
                            LocationId = entity.LocationId,
                            MondayOpen = entity.MondayOpen,
                            MondayClose = entity.MondayClose,
                            TuesdayOpen = entity.TuesdayOpen,
                            TuesdayClose = entity.TuesdayClose,
                            WednesdayOpen = entity.WednesdayOpen,
                            WednesdayClose = entity.WednesdayClose,
                            ThursdayOpen = entity.ThursdayOpen,
                            ThursdayClose = entity.ThursdayClose,
                            FridayOpen = entity.FridayOpen,
                            FridayClose = entity.FridayClose,
                            SaturdayOpen = entity.SaturdayOpen,
                            SaturdayClose = entity.SaturdayClose,
                            SundayOpen = entity.SundayOpen,
                            SundayClose = entity.SundayClose
                        };
                    }
                    else
                    {
                        throw new Exception("Schedule does not exist.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
