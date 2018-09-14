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
        OnlineDatabaseEntities db;

        /* Finds a record by using the given ID */
        public Staff Find(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Staff staff = db.Staffs.Find(id);
                db.Dispose();

                return staff;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();
                return null;
            }
        }

        /* Adds a record to the Database */
        public Boolean Add(Staff staff)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Staffs.Add(staff);
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
        public Boolean Update(Staff staff)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                db.Entry(staff).State = EntityState.Modified;
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
                Staff staff = db.Staffs.Find(id);
                staff.Status = "DEACTIVE";
                db.Entry(staff).State = EntityState.Modified;
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

        /* Changes Status of the record to Active */
        public Boolean Restore(int id)
        {
            try
            {
                db = new OnlineDatabaseEntities();
                Staff staff = db.Staffs.Find(id);
                staff.Status = "ACTIVE";
                db.Entry(staff).State = EntityState.Modified;
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

        /* Searches records using staff inputs */
        public IEnumerable<Staff> Search(string searchBy, string input, bool includeDeleted)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Staff> staffs = new List<Staff>();

                if (includeDeleted)
                {
                    if (searchBy == "ID")
                        staffs = db.Staffs.Where(staff => staff.Id.ToString().StartsWith(input)).ToList();
                    else if (searchBy == "NAME")
                        staffs = db.Staffs.Where(staff => staff.Name.StartsWith(input)).ToList();
                    else if (searchBy == "NIC")
                        staffs = db.Staffs.Where(staff => staff.NIC.StartsWith(input)).ToList();
                    else
                        staffs = db.Staffs.Where(staff => staff.Phone.StartsWith(input)).ToList();
                }
                else
                {
                    if (searchBy == "ID")
                        staffs = db.Staffs.Where(staff => staff.Id.ToString().StartsWith(input) && staff.Status == "ACTIVE").ToList();
                    else if (searchBy == "NAME")
                        staffs = db.Staffs.Where(staff => staff.Name.StartsWith(input) && staff.Status == "ACTIVE").ToList();
                    else if (searchBy == "NIC")
                        staffs = db.Staffs.Where(staff => staff.NIC.StartsWith(input) && staff.Status == "ACTIVE").ToList();
                    else
                        staffs = db.Staffs.Where(staff => staff.Phone.StartsWith(input) && staff.Status == "ACTIVE").ToList();
                }

                db.Dispose();

                return staffs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                db.Dispose();

                return null;
            }
        }

        /* Gets All Records */
        public IEnumerable<Staff> GetAll(bool includeDeleted)
        {
            try
            {
                db = new OnlineDatabaseEntities();

                List<Staff> staffs = new List<Staff>();

                if (includeDeleted)
                {
                    staffs = db.Staffs.ToList();
                }
                else
                {
                    staffs = db.Staffs.Where(staff => staff.Status == "ACTIVE").ToList();
                }

                db.Dispose();

                return staffs;
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
