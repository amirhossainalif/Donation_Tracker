using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, bool>, IAuth
    {
        public bool Create(Employee type)
        {
            db.Employees.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            
            db.Employees.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Read()
        {
            return db.Employees.ToList();
        }

        public Employee Read(int id)
        {
            return db.Employees.Find(id);
        }

        public bool Update(Employee type)
        {
            var ex = Read(type.Id);
            db.Entry(ex).CurrentValues.SetValues(type);
            return db.SaveChanges() > 0;
        }

        public bool Authenticate(int id, string pass, string type)
        {
            var Type = "Employee";
            var user = db.Employees.SingleOrDefault(u =>
                u.Id.Equals(id) && u.Password.Equals(pass) && Type == type
            );
            return user != null;
        }
    }
}
