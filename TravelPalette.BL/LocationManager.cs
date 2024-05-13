using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TravelPalette.BL;

namespace TravelPalette.BL
{
    public class LocationManager
    {
        public static int Insert(Location location, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    bool duplicateExists = dc.tblLocations.Any(l => l.AddressId == location.AddressId);
                    if (duplicateExists)
                    {
                        return 0;
                    }
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLocation entity = new tblLocation();
                    entity.Id = dc.tblLocations.Any() ? dc.tblLocations.Max(l => l.Id) + 1 : 1;
                    entity.AddressId = location.AddressId;
                    entity.Description = location.Description;
                    entity.BusinessName = location.BusinessName;
                    entity.Coordinates = location.Coordinates;
                    entity.PhoneNumber = location.PhoneNumber;

                    dc.tblLocations.Add(entity);
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

        public static int Update(Location location, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblLocation entity = dc.tblLocations.FirstOrDefault(l => l.Id == location.Id);

                    if (entity != null)
                    {
                        entity.AddressId = location.AddressId;
                        entity.Description = location.Description;
                        entity.BusinessName = location.BusinessName;
                        entity.Coordinates = location.Coordinates;
                        entity.PhoneNumber = location.PhoneNumber;

                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Location does not exist.");
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

                    tblLocation entity = dc.tblLocations.FirstOrDefault(l => l.Id == Id);

                    if (entity != null)
                    {
                        dc.tblLocations.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Location does not exist.");
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

        public static List<Location> Load()
        {
            try
            {
                List<Location> list = new List<Location>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from l in dc.tblLocations
                     select new
                     {
                         l.Id,
                         l.AddressId,
                         l.Description,
                         l.BusinessName,
                         l.Coordinates,
                         l.PhoneNumber
                     })
                     .ToList()
                     .ForEach(location => list.Add(new Location
                     {
                         Id = location.Id,
                         AddressId = location.AddressId,
                         Description = location.Description,
                         BusinessName = location.BusinessName,
                         Coordinates = location.Coordinates,
                         PhoneNumber = location.PhoneNumber
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Location LoadById(int id)
        {
            try
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblLocation entity = dc.tblLocations.FirstOrDefault(l => l.Id == id);
                    if (entity != null)
                    {
                        return new Location
                        {
                            Id = entity.Id,
                            AddressId = entity.AddressId,
                            Description = entity.Description,
                            BusinessName = entity.BusinessName,
                            Coordinates = entity.Coordinates,
                            PhoneNumber = entity.PhoneNumber
                        };
                    }
                    else
                    {
                        throw new Exception("Location does not exist.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Location> LoadByUserId(int userId)
        {
            try
            {

                List<Location> rows = new List<Location>();
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    var results = (from ul in dc.tblUserLists
                                   join li in dc.tblListItems on ul.Id equals li.Id
                                   join l in dc.tblLocations on li.LocationId equals l.AddressId
                                   where ul.UserId == userId && userId == li.Id
                                   select new
                                   {
                                       l.Id,
                                       l.AddressId,
                                       l.Description,
                                       l.BusinessName,
                                       l.Coordinates,
                                   }).ToList();
                    results.ForEach(r => rows.Add(
                         new Location
                         {
                             Id = r.Id,
                             AddressId = r.AddressId,
                             Description = r.Description,
                             BusinessName = r.BusinessName,
                             Coordinates = r.Coordinates,
                         }
                        ));
                }
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}