using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class AuthService
    {
        static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>();
            });
            return new Mapper(config);
        }

        public static TokenDTO Authenticate(int Id, string  Password, string Type)
        {
            if(Type == "Foundation")
            {
                var data = DataAccessFactory.AuthData().Authenticate(Id, Password, Type);
                if (data)
                {
                    Token t = new Token();
                    t.CreatedAt = DateTime.Now;
                    t.Key = Guid.NewGuid().ToString();
                    t.F_Id = Id;
                    t.E_Id = 1002;
                    t.D_Id = 1002;
                    t.User = Type;
                    var token = DataAccessFactory.TokenData().Create(t);
                    return GetMapper().Map<TokenDTO>(token);
                }
            }
            else if (Type == "Donor")
            {
                var data = DataAccessFactory.AuthData1().Authenticate(Id, Password, Type);
                if (data)
                {
                    Token t = new Token();
                    t.CreatedAt = DateTime.Now;
                    t.Key = Guid.NewGuid().ToString();
                    t.F_Id = 1013;
                    t.E_Id = 1002;
                    t.D_Id = Id;
                    t.User = Type;
                    var token = DataAccessFactory.TokenData().Create(t);
                    return GetMapper().Map<TokenDTO>(token);
                }
            }
            else if (Type == "Employee")
            {
                var data = DataAccessFactory.AuthData2().Authenticate(Id, Password, Type);
                if (data)
                {
                    Token t = new Token();
                    t.CreatedAt = DateTime.Now;
                    t.Key = Guid.NewGuid().ToString();
                    t.F_Id = 1013;
                    t.D_Id = 1002;
                    t.E_Id = Id;
                    t.User = Type;
                    var token = DataAccessFactory.TokenData().Create(t);
                    return GetMapper().Map<TokenDTO>(token);
                }
            }
            /*var data = DataAccessFactory.AuthData().Authenticate(Id, Password, Type);
            if(data)
            {
                Token t = new Token();
                t.CreatedAt = DateTime.Now;
                t.Key = Guid.NewGuid().ToString();
                t.F_Id = Id;
                var token = DataAccessFactory.TokenData().Create(t);    
                return GetMapper().Map<TokenDTO>(token);
            }*/
            return null;
        }

        public static bool LogoutToken(string key)
        {
            if (DataAccessFactory.TokenData().Read(key) != null)
            {
                Token token = new Token();
                token.Key = key;
                token.ExpiredAt = DateTime.Now;
                var ret = DataAccessFactory.TokenData().Update(token);
                return ret != null;
            }
            return false;
        }
        public static bool IsTokenValid(string key)
        {
            var token = DataAccessFactory.TokenData().Read(key);
            if (token != null && token.ExpiredAt == null) return true;
            return false;
        }
        

    }
}
