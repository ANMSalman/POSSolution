using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace POSSolution.Controllers.OnlineModels
{
    class UserController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public User Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                User user = db.Users.Find(id);
                db.Dispose();

                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(User user)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Users.Add(user);
                db.SaveChanges();
                db.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return false;
            }
        }

        /* Updates a record with new data */
        public Boolean Update(User user)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return false;
            }
        }

        /* Changes Status of the record to Deactive */
        public Boolean Delete(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                User user = db.Users.Find(id);
                user.Status = "DEACTIVE";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return false;
            }
        }

        /* Changes Status of the record to Active */
        public Boolean Restore(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                User user = db.Users.Find(id);
                user.Status = "ACTIVE";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return false;
            }
        }

        /* Searches records using user inputs */
        public IEnumerable<User> Search(string searchBy,string input, bool includeDeleted)
        {
            try
            {
                /*List<User> users = db.Users.Where(user => user.Name == input).IncludeFilter(user => user.Expenses.Where(expence => expence.Description == "Lunch")).ToList();

                foreach (User user in users)
                {
                    Console.WriteLine(user.Id + " " + user.Name);

                    foreach (Expense ex in user.Expenses)
                    {
                        Console.WriteLine(ex.Id+ " " + ex.Date);
                    }
                }*/

                db = new OnlineDatabaseEntities();

                List<User> users = new List<User>();

                if (includeDeleted)
                {
                    if (searchBy == "ID")
                        users = db.Users.Where(user => user.Id.ToString().StartsWith(input)).ToList();
                    else
                        users = db.Users.Where(user => user.Name.StartsWith(input)).ToList();
                }
                else
                {
                    if (searchBy == "ID")
                        users = db.Users.Where(user => user.Id.ToString().StartsWith(input) && user.Status=="ACTIVE").ToList();
                    else
                        users = db.Users.Where(user => user.Name.StartsWith(input) && user.Status == "ACTIVE").ToList();
                }

                db.Dispose();

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Gets All Records */
        public IEnumerable<User> GetAll(bool includeDeleted)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<User> users = new List<User>();

                if (includeDeleted)
                {
                    users = db.Users.ToList();
                }
                else
                {
                    users = db.Users.Where(user => user.Status == "ACTIVE").ToList();
                }

                db.Dispose();

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }
    }
}
