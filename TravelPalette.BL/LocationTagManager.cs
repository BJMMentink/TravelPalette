using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TravelPalette.BL;

namespace TravelPalette.BL
{
    public class LocationTagManager
    {
        public static int Insert(LocationTag locationTag, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLocationTag entity = new tblLocationTag();
                    entity.Id = dc.tblLocationTags.Any() ? dc.tblLocationTags.Max(lt => lt.Id) + 1 : 1;
                    entity.LocationId = locationTag.LocationId;
                    entity.TagId = locationTag.TagId;

                    dc.tblLocationTags.Add(entity);
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

        public static int Update(LocationTag locationTag, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLocationTag entity = dc.tblLocationTags.FirstOrDefault(lt => lt.Id == locationTag.Id);

                    if (entity != null)
                    {
                        entity.LocationId = locationTag.LocationId;
                        entity.TagId = locationTag.TagId;

                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("LocationTag does not exist.");
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

                    tblLocationTag entity = dc.tblLocationTags.FirstOrDefault(lt => lt.Id == Id);

                    if (entity != null)
                    {
                        dc.tblLocationTags.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("LocationTag does not exist.");
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

        public static List<LocationTag> Load()
        {
            try
            {
                List<LocationTag> list = new List<LocationTag>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from lt in dc.tblLocationTags
                     select new
                     {
                         lt.Id,
                         lt.LocationId,
                         lt.TagId
                     })
                     .ToList()
                     .ForEach(locationTag => list.Add(new LocationTag
                     {
                         Id = locationTag.Id,
                         LocationId = locationTag.LocationId,
                         TagId = locationTag.TagId
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static LocationTag LoadById(int id)
        {
            try
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblLocationTag entity = dc.tblLocationTags.FirstOrDefault(lt => lt.Id == id);
                    if (entity != null)
                    {
                        return new LocationTag
                        {
                            Id = entity.Id,
                            LocationId = entity.LocationId,
                            TagId = entity.TagId
                        };
                    }
                    else
                    {
                        throw new Exception("LocationTag does not exist.");
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
