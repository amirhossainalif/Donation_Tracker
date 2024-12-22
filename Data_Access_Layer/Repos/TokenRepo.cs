using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token type)
        {
            db.Tokens.Add(type);
            db.SaveChanges();
            return type;
        }


        public bool Delete(string id)
        {
            var ex = Read(id);

            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Token> Read()
        {
            return db.Tokens.ToList();
        }

        public Token Read(string id)
        {
            return db.Tokens.SingleOrDefault(t=>t.Key.Equals(id));
        }


        public Token Update(Token type)
        {
            var ex = Read(type.Key);
            //db.Entry(ex).CurrentValues.SetValues(type);
            ex.ExpiredAt = type.ExpiredAt;
            db.SaveChanges();
            return type; 
        }

    }
}
