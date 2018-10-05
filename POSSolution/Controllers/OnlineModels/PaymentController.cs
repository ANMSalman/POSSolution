using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class PaymentController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Payment Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Payment payment = db.Payments.Where(pay => pay.Id == id).Include(pay => pay.Supplier).ToList()[0];
                db.Dispose();

                return payment;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Finds a record by using the given ID */
        public List<Models.OnlineModels.Cheque> GetCheques(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                List<Models.OnlineModels.Cheque> cheques = db.Cheques.Where(cheque => cheque.PaymentId == id).Include(cheque=> cheque.Customer).ToList();
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

        /* Adds a record to the Database */
        public Boolean Add(Payment payment)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Payments.Add(payment);
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
        public Boolean Update(Payment payment)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(payment).State = EntityState.Modified;
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

        public Boolean UpdateCheques(List<Cheque> cheques)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                cheques.ForEach(cheque => cheque.Customer = null);
                cheques.ForEach(cheque => cheque.Payment = null);
                cheques.ForEach(cheque => db.Entry(cheque).State = EntityState.Modified);
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

        public Boolean MakeChequeNull(List<Cheque> cheques)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                cheques.ForEach(cheque => cheque.PaymentId = null);
                cheques.ForEach(cheque => cheque.Payment = null);
                cheques.ForEach(cheque => db.Entry(cheque).State = EntityState.Modified);
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
                
                List<Cheque> cheques = db.Cheques.Where(cheque => cheque.PaymentId == id).ToList();
                cheques.ForEach(cheque => cheque.PaymentId = null);
                cheques.ForEach(cheque => db.Entry(cheque).State = EntityState.Modified);
                db.SaveChanges();

                Payment payment = db.Payments.Find(id);
                db.Payments.Remove(payment);
                db.SaveChanges();

                if(payment.ReturnBillId !=null)
                {
                    db.ReturnBills.Remove(db.ReturnBills.Find(payment.ReturnBillId));
                    db.SaveChanges();
                }

                if (payment.PaymentBillId != null)
                {
                    db.PaymentBills.Remove(db.PaymentBills.Find(payment.PaymentBillId));
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
        public int GetCount(string searchBy, string input, string type)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                int count = 0;

                if (type == "ALL")
                {
                    if (searchBy == "ID")
                        count = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input)).Count();
                    else
                        count = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input)).Count();
                }
                else
                {
                    if (searchBy == "ID")
                        count = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input) && payment.Type == type).Count();
                    else
                        count = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input) && payment.Type == type).Count();
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
                        sum = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input)).Sum(payment => payment.Total);
                    else
                        sum = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input)).Sum(payment => payment.Total);
                }
                else
                {
                    if (searchBy == "ID")
                        sum = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input) && payment.Type == type).Sum(payment => payment.Total);
                    else
                        sum = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input) && payment.Type == type).Sum(payment => payment.Total);
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


        /* Searches records using payment inputs */
        public IEnumerable<Payment> Search(int pageIndex, string searchBy, string input, bool orderAscending, string type)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Payment> payments = new List<Payment>();
                if (type == "ALL")
                {
                    if (orderAscending)
                    {
                        if (searchBy == "ID")
                            payments = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input)).OrderBy(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                        else
                            payments = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input)).OrderBy(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                    }
                    else
                    {
                        if (searchBy == "ID")
                            payments = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input)).OrderByDescending(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                        else
                            payments = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input)).OrderByDescending(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                    }
                }
                else
                {
                    if (orderAscending)
                    {
                        if (searchBy == "ID")
                            payments = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input) && payment.Type == type).OrderBy(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                        else
                            payments = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input) && payment.Type == type).OrderBy(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                    }
                    else
                    {
                        if (searchBy == "ID")
                            payments = db.Payments.Where(payment => payment.Id.ToString().StartsWith(input) && payment.Type == type).OrderByDescending(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                        else
                            payments = db.Payments.Where(payment => payment.Supplier.Id.ToString().StartsWith(input) && payment.Type == type).OrderByDescending(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();
                    }
                }

                db.Dispose();

                return payments;
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

                count = db.Payments.Where(payment => payment.Date == input).Count();

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

                sum = db.Payments.Where(payment => payment.Date == input).Sum(payment => payment.Total);

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

        /* Searches records using payment inputs */
        public IEnumerable<Payment> Search(int pageIndex, DateTime input)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Payment> payments = new List<Payment>();

                payments = db.Payments.Where(payment => payment.Date == input).OrderBy(payment => payment.Date).Skip(pageIndex * 50).Take(50).Include(payment => payment.Supplier).ToList();

                db.Dispose();

                return payments;
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
