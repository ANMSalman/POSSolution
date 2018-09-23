using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class ExpenseController
    {
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Expense Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Expense expense = db.Expenses.Find(id);
                db.Dispose();

                return expense;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Expense expense)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Expenses.Add(expense);
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
        public Boolean Update(Expense expense)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(expense).State = EntityState.Modified;
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
                Expense expense = db.Expenses.Find(id);
                db.Expenses.Remove(expense);
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

        /* Searches records using expense inputs */
        public IEnumerable<Expense> Search(DateTime dateOn)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Expense> expenses = new List<Expense>();

                expenses = db.Expenses.Where(expense => expense.Date == dateOn).Include(expense=> expense.User).ToList();


                db.Dispose();

                return expenses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Searches records using expense inputs */
        public IEnumerable<Expense> Search(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Expense> expenses = new List<Expense>();

                expenses = db.Expenses.Where(expense => expense.Date >= dateFrom && expense.Date <= dateTo).Include(expense => expense.User).ToList();

                db.Dispose();

                return expenses;
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
