    using System.Security.Cryptography;
    using System.Text;
    using TravelPalette.BL.Models;
    using TravelPalette.PL;

    namespace TravelPalette.BL
    {
        //bmb added
        public class LoginFailureException : Exception
        {
            public LoginFailureException() : base("Cannot log in with these credentials. Your IP Address has been saved.")
            {

            }
            public LoginFailureException(string message) : base(message)
            {

            }
        }
        public static class UserManager
        {
            //bmb added
            public static string GetHash(string password)
            {
                using (var hasher = SHA1.Create())
                {
                    var hashbytes = Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
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
                        entity.Password = GetHash(user.Password); //bmb added Gethash
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
                            entity.Password = GetHash(user.Password);  //bmb added Gethash
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

            //bmb added/updated
            public static int Delete(int id, bool rollback = false)
            {
                try
                {
                    using (TravelPaletteEntities dc = new TravelPaletteEntities())
                    {
                        dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                        return dc.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            //bmb updated
            public static User LoadById(int id)
            {
                try
                {
                    using (TravelPaletteEntities dc = new TravelPaletteEntities())
                    {
                        var entity = (from u in dc.tblUsers
                                      select new
                                      {
                                          u.Id,
                                          u.FirstName,
                                          u.LastName,
                                          u.Username,
                                          u.Password,
                                          u.Email,
                                      })

                                         .FirstOrDefault();

                        if (entity != null)
                        {
                            return new User
                            {
                                Id = entity.Id,
                                FirstName = entity.FirstName,
                                LastName = entity.LastName,
                                Username = entity.Username,
                                Email = entity.Email,
                                Password = GetHash(entity.Password),
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

            //bmb updated
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
                             u.FirstName,
                             u.LastName,
                             u.Username,
                             u.Password,
                             u.Email,
                         })
                         .ToList()
                         .ForEach(user => list.Add(new User
                         {
                             Id = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Username = user.Username,
                             Email = user.Email,
                             Password = GetHash(user.Password),
                         }));
                    }
                    return list;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            //bmb added
            public static bool Login(User user)
            {
                try
                {
                    if (!string.IsNullOrEmpty(user.Username))
                    {
                        if (!string.IsNullOrEmpty(user.Password))
                        {
                            using (TravelPaletteEntities dc = new TravelPaletteEntities())
                            {
                                tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.Username == user.Username);
                                if (tblUser != null)
                                {
                                    if (tblUser.Password == GetHash(user.Password))
                                    {
                                        //login successful
                                        user.Id = tblUser.Id;
                                        user.FirstName = tblUser.FirstName;
                                        user.LastName = tblUser.LastName;
                                        return true;
                                    }
                                    else
                                    {
                                        throw new LoginFailureException();
                                    }
                                }
                                else
                                {
                                    throw new LoginFailureException("User was not found.");
                                }
                            }
                        }
                        else
                        {
                            throw new LoginFailureException("Password was not set.");
                        }
                    }
                    else
                    {
                        throw new LoginFailureException("Username was not set.");
                    }
                }
                catch (LoginFailureException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            //bmb added
            public static void Seed()
            {
                using (TravelPaletteEntities dc = new TravelPaletteEntities())
                {
                    //"if i don't have any make some"
                    if (!dc.tblUsers.Any())
                    {
                        User user = new User
                        {
                            Username = "john_doe",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "password123"
                        };
                        Insert(user);

                        user = new User
                        {
                            Username = "jane_smith",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Password = "letmein"
                        };
                        Insert(user);

                        user = new User
                        {
                            Username = "bob_johnson",
                            FirstName = "Bob",
                            LastName = "Johnson",
                            Password = "securepassword"
                        };
                        Insert(user);
                    }
                }
            }
        }
    }
