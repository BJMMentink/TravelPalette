using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public class TagManager
    {
        public static int Insert(Tag tag, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblTag entity = new tblTag();
                    entity.Id = dc.tblTags.Any() ? dc.tblTags.Max(s => s.Id) + 1 : 1;
                    entity.Description = tag.Description;

                    tag.Id = entity.Id; // Backfill the Id as a reference

                    dc.tblTags.Add(entity);
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
        public static int Update(Tag tag, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblTag entity = dc.tblTags.FirstOrDefault(s => s.Id == tag.Id);

                    if (entity != null)
                    {
                        entity.Description = tag.Description;
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

                    tblTag entity = dc.tblTags.FirstOrDefault(s => s.Id == Id);

                    if (entity != null)
                    {
                        dc.tblTags.Remove(entity); // Remove the row from the table
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
        public static List<Tag> Load()
        {
            try
            {
                List<Tag> list = new List<Tag>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from t in dc.tblTags
                     select new
                     {
                         t.Id,
                         t.Description,
                     })
                     .ToList()
                     .ForEach(tag => list.Add(new Tag
                     {
                         Id = tag.Id,
                         Description = tag.Description,
                     }));

                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Tag LoadById(int id)
        {
            try
            {
                using TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblTag entity = dc.tblTags.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Tag
                        {
                            Id = entity.Id,
                            Description = entity.Description,
                        };
                    }
                    else
                    {
                        throw new Exception();
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
