using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class ChequeController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Cheque Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Cheque cheque = db.Cheques.Where(che=> che.Id==id).Include(che=> che.Customer).ToList()[0];
                db.Dispose();

                return cheque;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Cheque cheque)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Cheques.Add(cheque);
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
        public Boolean Update(Cheque cheque)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(cheque).State = EntityState.Modified;
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
        public Boolean Returned(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Cheque cheque = db.Cheques.Find(id);
                cheque.Status = "RETURNED";
                db.Entry(cheque).State = EntityState.Modified;
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
        public Boolean Passed(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Cheque cheque = db.Cheques.Find(id);
                cheque.Status = "PASSED";
                db.Entry(cheque).State = EntityState.Modified;
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
        public int GetCount(string searchBy, string input, bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (returned)
                {
                    if (searchBy == "ID")
                        count = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input) && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "ADDED DATE")
                        count = db.Cheques.Where(cheque => cheque.AddedDate.ToString("dd-MM-yyyy") == input && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "NUMBER")
                        count = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input) && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "BANK")
                        count = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input) && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "BRANCH")
                        count = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input) && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "AMOUNT")
                        count = db.Cheques.Where(cheque => cheque.Amount.ToString() == input && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "CHEQUE DATE")
                        count = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "CUSTOMER")
                        count = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input && cheque.Status == "RETURNED").Count();
                    else
                        count = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input) && cheque.Status == "RETURNED").Count();
                }
                else
                {
                    if (searchBy == "ID")
                        count = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input)).Count();
                    else if (searchBy == "ADDED DATE")
                        count = db.Cheques.Where(cheque => cheque.AddedDate.ToString("dd-MM-yyyy") == input).Count();
                    else if (searchBy == "NUMBER")
                        count = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input)).Count();
                    else if (searchBy == "BANK")
                        count = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input)).Count();
                    else if (searchBy == "BRANCH")
                        count = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input)).Count();
                    else if (searchBy == "AMOUNT")
                        count = db.Cheques.Where(cheque => cheque.Amount.ToString() == input).Count();
                    else if (searchBy == "CHEQUE DATE")
                        count = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input).Count();
                    else if (searchBy == "CUSTOMER")
                        count = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input).Count();
                    else
                        count = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input)).Count();
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
        public double GetSum(string searchBy, string input, bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;

                if (returned)
                {
                    if (searchBy == "ID")
                        sum = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input) && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "ADDED DATE")
                        sum = db.Cheques.Where(cheque => cheque.AddedDate.ToString("dd-MM-yyyy") == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "NUMBER")
                        sum = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input) && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "BANK")
                        sum = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input) && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "BRANCH")
                        sum = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input) && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "AMOUNT")
                        sum = db.Cheques.Where(cheque => cheque.Amount.ToString() == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "CHEQUE DATE")
                        sum = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "CUSTOMER")
                        sum = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else
                        sum = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input) && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                }
                else
                {
                    if (searchBy == "ID")
                        sum = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input)).Sum(cheque => cheque.Amount);
                    else if (searchBy == "ADDED DATE")
                        sum = db.Cheques.Where(cheque => cheque.AddedDate.ToString("dd-MM-yyyy") == input).Sum(cheque => cheque.Amount);
                    else if (searchBy == "NUMBER")
                        sum = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input)).Sum(cheque => cheque.Amount);
                    else if (searchBy == "BANK")
                        sum = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input)).Sum(cheque => cheque.Amount);
                    else if (searchBy == "BRANCH")
                        sum = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input)).Sum(cheque => cheque.Amount);
                    else if (searchBy == "AMOUNT")
                        sum = db.Cheques.Where(cheque => cheque.Amount.ToString() == input).Sum(cheque => cheque.Amount);
                    else if (searchBy == "CHEQUE DATE")
                        sum = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input).Sum(cheque => cheque.Amount);
                    else if (searchBy == "CUSTOMER")
                        sum = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input).Sum(cheque => cheque.Amount);
                    else
                        sum = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input)).Sum(cheque => cheque.Amount);
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


        /* Searches records using cheque inputs */
        public IEnumerable<Cheque> Search(int pageIndex,string searchBy, string input,bool returned,bool orderAscending)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Cheque> cheques = new List<Cheque>();

                if (orderAscending)
                {
                    if (searchBy == "ID")
                        cheques = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input)).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "NUMBER")
                        cheques = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input)).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "BANK")
                        cheques = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input)).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "BRANCH")
                        cheques = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input)).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "AMOUNT")
                        cheques = db.Cheques.Where(cheque => cheque.Amount.ToString() == input).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CHEQUE DATE")
                        cheques = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CUSTOMER")
                        cheques = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else
                        cheques = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input)).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                }
                else
                {
                    if (searchBy == "ID")
                        cheques = db.Cheques.Where(cheque => cheque.Id.ToString().StartsWith(input)).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "NUMBER")
                        cheques = db.Cheques.Where(cheque => cheque.Number.ToString().StartsWith(input)).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "BANK")
                        cheques = db.Cheques.Where(cheque => cheque.Bank.StartsWith(input)).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "BRANCH")
                        cheques = db.Cheques.Where(cheque => cheque.Branch.StartsWith(input)).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "AMOUNT")
                        cheques = db.Cheques.Where(cheque => cheque.Amount.ToString() == input).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CHEQUE DATE")
                        cheques = db.Cheques.Where(cheque => cheque.Date.ToString("dd-MM-yyyy") == input).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CUSTOMER")
                        cheques = db.Cheques.Where(cheque => cheque.CustomerId.ToString() == input).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else
                        cheques = db.Cheques.Where(cheque => cheque.PaymentId.ToString().StartsWith(input)).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                }

                if (cheques != null && cheques.Count > 0)
                {
                    if (returned)
                        cheques = cheques.Where(cheque => cheque.Status == "RETURNED").ToList();
                }


                db.Dispose();

                return cheques;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /*Gets count of the records for the search with dates*/
        public int GetCount(string searchBy, DateTime input, bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (returned)
                {
                    if (searchBy == "ADDED DATE")
                        count = db.Cheques.Where(cheque => cheque.AddedDate == input && cheque.Status == "RETURNED").Count();
                    else if (searchBy == "CHEQUE DATE")
                        count = db.Cheques.Where(cheque => cheque.Date == input && cheque.Status == "RETURNED").Count();
                }
                else
                {
                    if (searchBy == "ADDED DATE")
                        count = db.Cheques.Where(cheque => cheque.AddedDate == input).Count();
                    else if (searchBy == "CHEQUE DATE")
                        count = db.Cheques.Where(cheque => cheque.Date == input).Count();
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

        /*Gets sum of the Amount of records for the search with dates*/
        public double GetSum(string searchBy, DateTime input, bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;

                if (returned)
                {
                    if (searchBy == "ADDED DATE")
                        sum = db.Cheques.Where(cheque => cheque.AddedDate == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                    else if (searchBy == "CHEQUE DATE")
                        sum = db.Cheques.Where(cheque => cheque.Date == input && cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                }
                else
                {
                    if (searchBy == "ADDED DATE")
                        sum = db.Cheques.Where(cheque => cheque.AddedDate == input).Sum(cheque => cheque.Amount);
                    else if (searchBy == "CHEQUE DATE")
                        sum = db.Cheques.Where(cheque => cheque.Date == input).Sum(cheque => cheque.Amount);
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

        /* Searches records using cheque date */
        public IEnumerable<Cheque> Search(int pageIndex, string searchBy, DateTime input, bool returned, bool orderAscending)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Cheque> cheques = new List<Cheque>();

                if (orderAscending)
                {
                    if (searchBy == "ADDED DATE")
                        cheques = db.Cheques.Where(cheque => cheque.AddedDate == input).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CHEQUE DATE")
                        cheques = db.Cheques.Where(cheque => cheque.Date == input).OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                }
                else
                {
                    if (searchBy == "ADDED DATE")
                        cheques = db.Cheques.Where(cheque => cheque.AddedDate == input).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else if (searchBy == "CHEQUE DATE")
                        cheques = db.Cheques.Where(cheque => cheque.Date == input).OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                }

                if (cheques != null && cheques.Count > 0)
                {
                    if (returned)
                        cheques = cheques.Where(cheque => cheque.Status == "RETURNED").ToList();
                }


                db.Dispose();

                return cheques;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /*Gets count of the records for all records*/
        public int GetCount(bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (returned)
                    count = db.Cheques.Where(cheque => cheque.Status == "RETURNED").Count();
                else
                    count = db.Cheques.Count();

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

        /*Gets sum of the Amount of records for all records*/
        public double GetSum(bool returned)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                double sum = 0;

                if (returned)
                    sum = db.Cheques.Where(cheque => cheque.Status == "RETURNED").Sum(cheque => cheque.Amount);
                else
                    sum = db.Cheques.Sum(cheque=> cheque.Amount);

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

        /* Gets All Records */
        public IEnumerable<Cheque> GetAll(int pageIndex, bool returned, bool orderAscending)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Cheque> cheques = new List<Cheque>();

                if (pageIndex == 0)
                {
                    if (orderAscending)
                        cheques = db.Cheques.OrderBy(cheque => cheque.Id).Take(50).Include(cheque => cheque.Customer).ToList();
                    else
                        cheques = db.Cheques.OrderByDescending(cheque => cheque.Id).Take(50).Include(cheque => cheque.Customer).ToList();
                }
                else
                {
                    if (orderAscending)
                        cheques = db.Cheques.OrderBy(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                    else
                        cheques = db.Cheques.OrderByDescending(cheque => cheque.Id).Skip(pageIndex * 50).Take(50).Include(cheque => cheque.Customer).ToList();
                }

                if (cheques != null && cheques.Count > 0)
                {
                    if (returned)
                        cheques = cheques.Where(cheque => cheque.Status == "RETURNED").ToList();
                }

                db.Dispose();

                return cheques;
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

        /* Gets all Banks to fill AutoComplete Bank TextBox in AddEditForm*/
        public IEnumerable<string> GetBanks()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<string> banks = new List<string>();

                banks = db.Cheques.Select(cheque=> cheque.Bank).Distinct().ToList();

                db.Dispose();

                return banks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Gets all Banks to fill AutoComplete Bank TextBox in AddEditForm*/
        public IEnumerable<string> GetBranches()
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<string> branches = new List<string>();

                branches = db.Cheques.Select(cheque => cheque.Branch).Distinct().ToList();

                db.Dispose();

                return branches;
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
