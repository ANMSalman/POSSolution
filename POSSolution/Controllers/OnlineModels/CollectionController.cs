using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class CollectionController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Collection Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Collection collection = db.Collections.Where(col => col.Id == id).Include(col => col.Customer).ToList()[0];
                db.Dispose();

                return collection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Collection collection)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Collections.Add(collection);
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
        public Boolean Update(Collection collection)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(collection).State = EntityState.Modified;
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
                Collection collection = db.Collections.Find(id);
                db.Collections.Remove(collection);
                db.SaveChanges();

                if (collection.ReturnBillId != null)
                {
                    db.ReturnBills.Remove(db.ReturnBills.Find(collection.ReturnBillId));
                    db.SaveChanges();
                }

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


        /*Gets count of the records for the search with text*/
        public int GetCount(string searchBy, string input,string type)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (type == "ALL")
                {
                    if (searchBy == "ID")
                        count = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input)).Count();
                    else
                        count = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input)).Count();
                }
                else
                {
                    if (searchBy == "ID")
                        count = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input) && collection.Type == type).Count();
                    else
                        count = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input) && collection.Type == type).Count();
                }

                db.Dispose();

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return 0;
            }
        }

        /*Gets Sum of the Amount of records for the search with text*/
        public double GetSum(string searchBy, string input, string type)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;

                if (type == "ALL")
                {
                    if (searchBy == "ID")
                        sum = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input)).Sum(collection => collection.Total);
                    else
                        sum = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input)).Sum(collection => collection.Total);
                }
                else
                {
                    if (searchBy == "ID")
                        sum = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input) && collection.Type == type).Sum(collection => collection.Total);
                    else
                        sum = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input) && collection.Type == type).Sum(collection => collection.Total);
                }


                db.Dispose();

                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return 0;
            }
        }


        /* Searches records using collection inputs */
        public IEnumerable<Collection> Search(int pageIndex, string searchBy, string input, bool orderAscending,string type)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Collection> collections = new List<Collection>();
                if (type == "ALL")
                {
                    if (orderAscending)
                    {
                        if (searchBy == "ID")
                            collections = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input)).OrderBy(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                        else
                            collections = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input)).OrderBy(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                    }
                    else
                    {
                        if (searchBy == "ID")
                            collections = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input)).OrderByDescending(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                        else
                            collections = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input)).OrderByDescending(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                    }
                }
                else
                {
                    if (orderAscending)
                    {
                        if (searchBy == "ID")
                            collections = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input) && collection.Type==type).OrderBy(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                        else
                            collections = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input) && collection.Type == type).OrderBy(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                    }
                    else
                    {
                        if (searchBy == "ID")
                            collections = db.Collections.Where(collection => collection.Id.ToString().StartsWith(input) && collection.Type == type).OrderByDescending(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                        else
                            collections = db.Collections.Where(collection => collection.Customer.Id.ToString().StartsWith(input) && collection.Type == type).OrderByDescending(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();
                    }
                }

                db.Dispose();

                return collections;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /*Gets count of the records for the search with dates*/
        public int GetCount(DateTime input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                count = db.Collections.Where(collection => collection.Date == input).Count();

                db.Dispose();

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return 0;
            }
        }

        /*Gets sum of the Amount of records for the search with dates*/
        public double GetSum(DateTime input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;

                sum = db.Collections.Where(collection => collection.Date == input).Sum(collection => collection.Total);

                db.Dispose();

                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return 0;
            }
        }

        /* Searches records using collection inputs */
        public IEnumerable<Collection> Search(int pageIndex, DateTime input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Collection> collections = new List<Collection>();

                collections = db.Collections.Where(collection => collection.Date == input).OrderBy(collection => collection.Date).Skip(pageIndex * 50).Take(50).Include(collection => collection.Customer).ToList();

                db.Dispose();

                return collections;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }


        /* Gets all customers to fill Customer ComboBox in AddEditForm*/
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Customer> customers = new List<Customer>();

                customers = db.Customers.ToList();

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
