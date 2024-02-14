﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TravelPalette.BL.Models;

namespace TravelPalette.BL
{
    public class UserListManager
    {
        public static int Insert(UserList userList, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUserList entity = new tblUserList();
                    entity.Id = dc.tblUserLists.Any() ? dc.tblUserLists.Max(ul => ul.Id) + 1 : 1;
                    entity.UserId = userList.UserId;
                    entity.ListId = userList.ListId;
                    entity.ListName = userList.ListName;

                    dc.tblUserLists.Add(entity);
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

        public static int Update(UserList userList, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUserList entity = dc.tblUserLists.FirstOrDefault(ul => ul.Id == userList.Id);

                    if (entity != null)
                    {
                        entity.UserId = userList.UserId;
                        entity.ListId = userList.ListId;
                        entity.ListName = userList.ListName;

                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("UserList does not exist.");
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

                    tblUserList entity = dc.tblUserLists.FirstOrDefault(ul => ul.Id == Id);

                    if (entity != null)
                    {
                        dc.tblUserLists.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("UserList does not exist.");
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

        public static List<UserList> Load()
        {
            try
            {
                List<UserList> list = new List<UserList>();

                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    (from ul in dc.tblUserLists
                     select new
                     {
                         ul.Id,
                         ul.UserId,
                         ul.ListId,
                         ul.ListName
                     })
                     .ToList()
                     .ForEach(userList => list.Add(new UserList
                     {
                         Id = userList.Id,
                         UserId = userList.UserId,
                         ListId = userList.ListId,
                         ListName = userList.ListName
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static UserList LoadById(int id)
        {
            try
            {
                using (ProgDecEntities dc = new ProgDecEntities())
                {
                    tblUserList entity = dc.tblUserLists.FirstOrDefault(ul => ul.Id == id);
                    if (entity != null)
                    {
                        return new UserList
                        {
                            Id = entity.Id,
                            UserId = entity.UserId,
                            ListId = entity.ListId,
                            ListName = entity.ListName
                        };
                    }
                    else
                    {
                        throw new Exception("UserList does not exist.");
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