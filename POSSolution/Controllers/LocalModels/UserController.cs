using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace POSSolution.Controllers.LocalModels
{
    class UserController
    {
        LocalDatabaseEntities db = new LocalDatabaseEntities();

        /* Finds a record by using the given ID */
        public User Find(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Updates a record with new data */
        public Boolean Update(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Deletes a record */
        public Boolean Delete(User user)
        {
            try
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Searches records using user inputs */
        public IEnumerable<User> Search(string input)
        {
            try
            {
                List<User> users = db.Users.Where(user => user.Name == input).IncludeFilter(user => user.Expenses.Where(expence => expence.Description == "Lunch")).ToList();

                foreach (User user in users)
                {
                    Console.WriteLine(user.Id + " " + user.Name);

                    foreach (Expense ex in user.Expenses)
                    {
                        Console.WriteLine(ex.Id+ " " + ex.Date);
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
