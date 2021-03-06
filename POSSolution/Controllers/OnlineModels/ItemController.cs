﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class ItemController
    {

        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Item Find(string Name)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Item item = db.Items.Where(itm=>itm.Name==Name).ToList()[0];
                db.Dispose();

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Item item)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Items.Add(item);
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
        public Boolean Update(Item item)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(item).State = EntityState.Modified;
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
        public Boolean Delete(string name)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Item item = db.Items.Find(name);
                db.Items.Remove(item);
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
        
        /* Searches records using item inputs */
        public IEnumerable<Item> Search(string input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Item> items = new List<Item>();

                items = db.Items.Where(item => item.Name.StartsWith(input)).ToList();


                db.Dispose();

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Gets All Records */
        public IEnumerable<Item> GetAll()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Item> items = new List<Item>();


                items = db.Items.ToList();

                db.Dispose();

                return items;
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
