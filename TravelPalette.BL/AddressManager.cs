using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public  class AddressManager
    {
        public static int Insert(Address address, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAddress entity = new tblAddress();
                    entity.Id = dc.tblAddresss.Any() ? dc.tblAddresss.Max(s => s.Id) + 1 : 1;
                    entity.StreetName = address.StreetName;
                    entity.City = address.City;
                    entity.ZIP = address.ZIP;
                    entity.State = address.State;

                    address.Id = entity.Id; // Backfill the Id as a reference

                    dc.tblAddresss.Add(entity);
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
        public static int Update(Address address, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAddress entity = dc.tblAddresss.FirstOrDefault(s => s.Id == address.Id);

                    if (entity != null)
                    {
                        entity.StreetName = address.StreetName;
                        entity.City = address.City;
                        entity.ZIP = address.ZIP;
                        entity.State = address.State;

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
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAddress entity = dc.tblAddresss.FirstOrDefault(s => s.Id == Id);

                    if (entity != null)
                    {
                        dc.tblAddresss.Remove(entity); // Remove the row from the table
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
        public static List<Address> Load()
        {
            try
            {
                List<Address> list = new List<Address>();

                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from a in dc.tblAddresss
                     select new
                     {
                         a.StreetName,
                         a.City,
                         a.ZIP,
                         a.State
                     })
                     .ToList()
                     .ForEach(address => list.Add(new Address
                     {
                         Id = address.Id,
                         StreetName = address.StreetName,
                         City = address.City,
                         ZIP = address.ZIP,
                         State = address.State,
                     }));

                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Address LoadById(int id)
        {
            try
            {
                using ProgDecEntities dc = new ProgDecEntities())
                {
                    tblAddress entity = dc.tblAddresss.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Address
                        {
                            Id = entity.Id,
                            StreetName = entity.StreetName,
                            City = entity.City,
                            ZIP = entity.ZIP,
                            State = entity.State,
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
