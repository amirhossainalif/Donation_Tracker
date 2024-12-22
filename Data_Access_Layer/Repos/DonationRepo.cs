using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class DonationRepo : Repo, IRepo<Donation, int, bool>
    {
        public bool Create(Donation type)
        {
            db.Donations.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Donation> Read()
        {
            return db.Donations.ToList();
        }

        public Donation Read(int id)
        {
            return db.Donations.Find(id);
        }
        public Donation ReadDonar(int id)
        {
            //var r = Read(id);
            //var z =  db.Donations.Find(id).D_id;
            //return db.Donations.Find(z);
            return db.Donations.SingleOrDefault(u =>
                u.D_id.Equals(id));
        }

        public bool Update(Donation type)
        {
            throw new NotImplementedException();
        }

        /*public bool Authenticate(int id, string pass, string type)
        {
            var Type = "Employee";
            var user = db.Employees.SingleOrDefault(u =>
                u.Id.Equals(id) && u.Password.Equals(pass) && Type == type
            );
            return user != null;
        }*/
    }
}
