using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models;
using System.Data.Entity;

namespace POSSolution.Controllers.LocalModels
{
    class CustomerController
    {
        LocalDatabaseEntities db = new LocalDatabaseEntities();

        /* Finds a record by using the given ID */
        public Customer Find(int id)
        {
            try
            {
                Customer customer = db.Customers.Find(id);
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
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
        public Boolean Update(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
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
        public Boolean Delete(Customer customer)
        {
            try
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Searches records using customer inputs */
        public IEnumerable<Customer> Search(string input)
        {
            try
            {
                List<Customer> customers = db.Customers.Where(customer => customer.Name == input).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
