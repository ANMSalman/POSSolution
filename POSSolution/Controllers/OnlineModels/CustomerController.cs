using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class CustomerController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Customer Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Customer customer = db.Customers.Find(id);
                db.Dispose();

                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Customer customer)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Customers.Add(customer);
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
        public Boolean Update(Customer customer)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(customer).State = EntityState.Modified;
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


        /* Searches records using customer inputs */
        public IEnumerable<Customer> Search(string searchBy, string input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Customer> customers = new List<Customer>();


                if (searchBy == "ID")
                    customers = db.Customers.Where(customer => customer.Id.ToString().StartsWith(input)).Include(customer=> customer.User).ToList();
                else if (searchBy == "NAME")
                    customers = db.Customers.Where(customer => customer.Name.StartsWith(input)).Include(customer => customer.User).ToList();
                else if (searchBy == "NIC")
                    customers = db.Customers.Where(customer => customer.NIC.StartsWith(input)).Include(customer => customer.User).ToList();
                else
                    customers = db.Customers.Where(customer => customer.Phone.StartsWith(input)).Include(customer => customer.User).ToList();


                db.Dispose();

                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Gets All Records */
        public IEnumerable<Customer> GetAll()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Customer> customers = new List<Customer>();

                customers = db.Customers.Include(customer => customer.User).ToList();

                db.Dispose();

                return customers;
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
