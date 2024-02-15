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

                    entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
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
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == user.Id);
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
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == id);
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
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new User
                        {
                            Id = entity.Id,
                            Username = entity.Username,





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
        public static List<User> Load(int studentId)
        {
            try
            {
                List<User> list = new List<User>();

                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    (from a in dc.tblUsers
                     join sa in dc.tblStudentUsers on a.Id equals sa.UserId
                     where sa.StudentId == studentId
                     select new
                     {
                         a.Id,
                         a.Name
                     })
                     .ToList()
                     .ForEach(user => list.Add(new User
                     {
                         Id = user.Id,
                         Name = user.Name
                     }));
                }
                return list;
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
                    (from s in dc.tblUsers
                     select new
                     {
                         s.Id,
                         s.Name
                     })
                     .ToList()
                     .ForEach(user => list.Add(new User
                     {
                         Id = user.Id,
                         Name = user.Name
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
