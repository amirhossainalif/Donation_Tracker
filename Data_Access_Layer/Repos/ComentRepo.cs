using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class ComentRepo : Repo, IRepo<Comment, int, bool>
    {
        public bool Create(Comment type)
        {
            db.Comments.Add(type);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);

            db.Comments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Comment> Read()
        {
            throw new NotImplementedException();
        }

        public Comment Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment type)
        {
            var ex = Read(type.Id);
            db.Entry(ex).CurrentValues.SetValues(type);
            return db.SaveChanges() > 0;
        }
    }
}
