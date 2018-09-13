using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSSolution.Models.OnlineModels;
using System.Data.Entity;

namespace POSSolution.Controllers.OnlineModels
{
    class StaffController
    {
        OnlineDatabaseEntities db = new OnlineDatabaseEntities();

        /* Finds a record by using the given ID */
        public Staff Find(int id)
        {
            try
            {
                Staff staff = db.Staffs.Find(id);
                return staff;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Staff staff)
        {
            try
            {
                db.Staffs.Add(staff);
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
        public Boolean Update(Staff staff)
        {
            try
            {
                db.Entry(staff).State = EntityState.Modified;
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
        public Boolean Delete(Staff staff)
        {
            try
            {
                db.Staffs.Remove(staff);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /* Searches records using staff inputs */
        public IEnumerable<Staff> Search(string input)
        {
            try
            {
                List<Staff> staffs = db.Staffs.Where(staff => staff.Name == input).ToList();
                return staffs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
