using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public class ListItemManager
    {
        public static int Insert(ListItem listItem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblListItem entity = new tblListItem();
                    entity.Id = dc.tblListItems.Any() ? dc.tblListItems.Max(li => li.Id) + 1 : 1;
                    entity.LocationId = listItem.LocationId;

                    dc.tblListItems.Add(entity);
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

        public static int Update(ListItem listItem, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblListItem entity = dc.tblListItems.FirstOrDefault(li => li.Id == listItem.Id);

                    if (entity != null)
                    {
                        entity.LocationId = listItem.LocationId;

                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ListItem does not exist.");
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

                    tblListItem entity = dc.tblListItems.FirstOrDefault(li => li.Id == Id);

                    if (entity != null)
                    {
                        dc.tblListItems.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ListItem does not exist.");
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

        public static List<ListItem> Load()
        {
            try
            {
                List<ListItem> list = new List<ListItem>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from li in dc.tblListItems
                     select new
                     {
                         li.Id,
                         li.LocationId
                     })
                     .ToList()
                     .ForEach(listItem => list.Add(new ListItem
                     {
                         Id = listItem.Id,
                         LocationId = listItem.LocationId
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ListItem LoadById(int id)
        {
            try
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblListItem entity = dc.tblListItems.FirstOrDefault(li => li.Id == id);
                    if (entity != null)
                    {
                        return new ListItem
                        {
                            Id = entity.Id,
                            LocationId = entity.LocationId
                        };
                    }
                    else
                    {
                        throw new Exception("ListItem does not exist.");
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