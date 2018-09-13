using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class ItemController
    {
        OnlineDatabaseEntities db = new OnlineDatabaseEntities();

        /* Finds a record by using the given ID */
        public Item Find(int id)
        {
            try
            {
                Item item = db.Items.Find(id);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Item item)
        {
            try
            {
                db.Items.Add(item);
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
        public Boolean Update(Item item)
        {
            try
            {
                db.Entry(item).State = EntityState.Modified;
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
        public Boolean Delete(Item item)
        {
            try
            {
                db.Items.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Searches records using item inputs */
        public IEnumerable<Item> Search(string input)
        {
            try
            {
                List<Item> items = db.Items.Where(item => item.Name == input).ToList();
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
