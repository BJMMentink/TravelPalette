using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public static class UserManager
    {
        public static int Insert(string userName,
                                 string password,
                                 string email,
                                 string firstName,
                                 string lastName,
                                 ref int id,
                                 bool rollback = false)
        {
            try
            {
                User user = new User
                {
                    Username = userName,
                    Password = password,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                };
                int results = Insert(user, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = user.Id;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser entity = new tblUser();

                    entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(u => u.Id) + 1 : 1;
                    entity.Username = user.Username;
                    entity.Password = user.Password;
                    entity.Email = user.Email;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;

                    // IMPORTANT - BACK FILL THE ID
                    user.Id = entity.Id;

                    dc.tblUsers.Add(entity);
                    results += dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row we are trying to update
                    tblUser entity = dc.tblUsers.FirstOrDefault(u => u.Id == user.Id);
                    if (entity != null)
                    {
                        entity.Username = user.Username;
                        entity.Password = user.Password;
                        entity.Email = user.Email;
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row we are trying to update
                    tblUser entity = dc.tblUsers.FirstOrDefault(u => u.Id == id);
                    if (entity != null)
                    {
                        dc.tblUsers.Remove(entity);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static User LoadById(int id)
        {
            try
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    tblUser entity = dc.tblUsers.FirstOrDefault(u => u.Id == id);

                    if (entity != null)
                    {
                        return new User
                        {
                            Id = entity.Id,
                            Username = entity.Username,
                            Password = entity.Password,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Email = entity.Email
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
        public static List<User> Load()
        {
            try
            {
                List<User> list = new List<User>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from u in dc.tblUsers
                     select new
                     {
                         u.Id,
                         u.Username,
                         u.Password,
                         u.FirstName,
                         u.LastName,
                         u.Email
                     })
                     .ToList()
                     .ForEach(user => list.Add(new User
                     {
                         Id = user.Id,
                         Username = user.Username,
                         Password = user.Password,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         Email = user.Email
                     }));

                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
