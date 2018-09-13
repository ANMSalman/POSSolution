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
        OnlineDatabaseEntities db = new OnlineDatabaseEntities();

        /* Finds a record by using the given ID */
        public Expense Find(int id)
        {
            try
            {
                Expense expense = db.Expenses.Find(id);
                return expense;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Expense expense)
        {
            try
            {
                db.Expenses.Add(expense);
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
        public Boolean Update(Expense expense)
        {
            try
            {
                db.Entry(expense).State = EntityState.Modified;
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
        public Boolean Delete(Expense expense)
        {
            try
            {
                db.Expenses.Remove(expense);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Searches records using expense inputs */
        public IEnumerable<Expense> Search(string input)
        {
            try
            {
                List<Expense> expenses = db.Expenses.Where(expense => expense.Description == input).ToList();
                return expenses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
