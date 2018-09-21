using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class SupplierController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Supplier Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Supplier supplier = db.Suppliers.Find(id);
                db.Dispose();

                return supplier;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Supplier supplier)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Suppliers.Add(supplier);
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
        public Boolean Update(Supplier supplier)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(supplier).State = EntityState.Modified;
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


        /* Searches records using supplier inputs */
        public IEnumerable<Supplier> Search(string searchBy, string input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Supplier> suppliers = new List<Supplier>();


                if (searchBy == "ID")
                    suppliers = db.Suppliers.Where(supplier => supplier.Id.ToString().StartsWith(input)).ToList();
                else if (searchBy == "NAME")
                    suppliers = db.Suppliers.Where(supplier => supplier.Name.StartsWith(input)).ToList();
                else if (searchBy == "ACCOUNT NAME")
                    suppliers = db.Suppliers.Where(supplier => supplier.AccountName.StartsWith(input)).ToList();
                else if (searchBy == "ACCOUNT NO")
                    suppliers = db.Suppliers.Where(supplier => supplier.AccountNo.StartsWith(input)).ToList();
                else if (searchBy == "BANK")
                    suppliers = db.Suppliers.Where(supplier => supplier.Bank.StartsWith(input)).ToList();
                else if (searchBy == "BRANCH")
                    suppliers = db.Suppliers.Where(supplier => supplier.Branch.StartsWith(input)).ToList();
                else
                    suppliers = db.Suppliers.Where(supplier => supplier.Phone.StartsWith(input)).ToList();


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

        /* Gets All Records */
        public IEnumerable<Supplier> GetAll()
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
