using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class DonorRepo : Repo, IRepo<Donor, int, bool>, IAuth
    {
        public bool Create(Donor type)
        {
            db.Donors.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int type)
        {
            var ex = Read(type);
            db.Donors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Donor> Read()
        {
            return db.Donors.ToList();
        }

        public Donor Read(int id)
        {
            return db.Donors.Find(id);
        }

        public bool Update(Donor type)
        {
            var ex = Read(type.Id);
            db.Entry(ex).CurrentValues.SetValues(type);
            return db.SaveChanges() > 0;
        }

        public bool Authenticate(int id, string pass, string type)
        {
            var Type = "Donor";
            var user = db.Donors.SingleOrDefault(u =>
                u.Id.Equals(id) && u.Password.Equals(pass) && Type == type
            );
            return user != null;
        }
    }
}
