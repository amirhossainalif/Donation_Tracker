using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class FoundationRepo : Repo, IRepo<Foundation, int, bool>, IAuth
    {
        public bool Create(Foundation type)
        {
            db.Foundations.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Foundations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Foundation> Read()
        {
            return db.Foundations.ToList();
        }

        public Foundation Read(int id)
        {
            return db.Foundations.Find(id);
        }

        public bool Update(Foundation type)
        {
            var ex = Read(type.Id);
            db.Entry(ex).CurrentValues.SetValues(type);
            return db.SaveChanges() > 0;
        }

        public bool Authenticate(int id, string pass, string type)
        {
            var Type = "Foundation";
            var user = db.Foundations.SingleOrDefault(u=>
                u.Id.Equals(id) && u.Password.Equals(pass) && Type == type
            );
            return user != null;
        }
    }
}
