using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class PurchaseController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Purchase Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Purchase purchase = db.Purchases.Where(pur => pur.Id == id).Include(pur => pur.Supplier).ToList()[0];
                db.Dispose();

                return purchase;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Purchase purchase)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Purchases.Add(purchase);
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
        public Boolean Update(Purchase purchase)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(purchase).State = EntityState.Modified;
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
                Purchase purchase = db.Purchases.Find(id);
                db.Purchases.Remove(purchase);
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


        /*Gets count of the records for the search with text*/
        public int GetCount(string searchBy, string input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (searchBy == "ID")
                    count = db.Purchases.Where(purchase => purchase.Id.ToString().StartsWith(input)).Count();
                else if (searchBy == "AMOUNT")
                    count = db.Purchases.Where(purchase => purchase.Amount.ToString() == input).Count();
                else
                    count = db.Purchases.Where(purchase => purchase.Supplier.Id.ToString().StartsWith(input)).Count();

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
        public double GetSum(string searchBy, string input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;


                if (searchBy == "ID")
                    sum = db.Purchases.Where(purchase => purchase.Id.ToString().StartsWith(input)).Sum(purchase => purchase.Amount);
                if (searchBy == "AMOUNT")
                    sum = db.Purchases.Where(purchase => purchase.Amount.ToString() == input).Sum(purchase => purchase.Amount);
                else
                    sum = db.Purchases.Where(purchase => purchase.Supplier.Id.ToString().StartsWith(input)).Sum(purchase => purchase.Amount);


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


        /* Searches records using purchase inputs */
        public IEnumerable<Purchase> Search(int pageIndex,string searchBy, string input, bool orderAscending)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Purchase> purchases = new List<Purchase>();

                if (orderAscending)
                {
                    if (searchBy == "ID")
                        purchases = db.Purchases.Where(purchase => purchase.Id.ToString().StartsWith(input)).OrderBy(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                    else if (searchBy == "AMOUNT")
                        purchases = db.Purchases.Where(purchase => purchase.Amount.ToString() == input).OrderBy(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                    else
                        purchases = db.Purchases.Where(purchase => purchase.Supplier.Id.ToString().StartsWith(input)).OrderBy(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                }
                else
                {
                    if (searchBy == "ID")
                        purchases = db.Purchases.Where(purchase => purchase.Id.ToString().StartsWith(input)).OrderByDescending(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                    else if (searchBy == "AMOUNT")
                        purchases = db.Purchases.Where(purchase => purchase.Amount.ToString() == input).OrderByDescending(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                    else
                        purchases = db.Purchases.Where(purchase => purchase.Supplier.Id.ToString().StartsWith(input)).OrderByDescending(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                }

                db.Dispose();

                return purchases;
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

                count = db.Purchases.Where(purchase => purchase.Date == input).Count();
                
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

                sum = db.Purchases.Where(purchase => purchase.Date == input).Sum(purchase => purchase.Amount);

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

        /* Searches records using purchase inputs */
        public IEnumerable<Purchase> Search(int pageIndex,DateTime input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Purchase> purchases = new List<Purchase>();

                purchases = db.Purchases.Where(purchase => purchase.Date == input).OrderBy(purchase => purchase.Date).Skip(pageIndex * 50).Take(50).Include(purchase => purchase.Supplier).ToList();
                
                db.Dispose();

                return purchases;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }
        

        /* Gets all suppliers to fill Supplier ComboBox in AddEditForm*/
        public IEnumerable<Supplier> GetSuppliers()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Supplier> suppliers = new List<Supplier>();

                suppliers = db.Suppliers.ToList();

                db.Dispose();

                return suppliers;
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
