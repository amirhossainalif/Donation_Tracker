using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.Tables;
using Data_Access_Layer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DataAccessFactory
    {
        public static IRepo<Donation, int, bool> DonationData()
        {
            return new DonationRepo();
        }
        public static IRepo<Donor, int, bool> DonarData()
        {
            return new DonorRepo();
        }

        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepo();
        }

        public static IRepo<Foundation, int, bool> FundationData()
        {
            return new FoundationRepo();
        }
        public static IAuth AuthData() {
            
            return new FoundationRepo();
        }

        public static IAuth AuthData1()
        {
            return new DonorRepo();
        }
        public static IAuth AuthData2()
        {
            return new EmployeeRepo();
        }


        public static IRepo<Token, string, Token> TokenData() { 
            return new TokenRepo();
        }

        public static IRepo<Post, int, bool> PostData() { 
            return new PostRepo();
        }
        public static IRepo<Comment, int, bool> CommentData() { 
            return new ComentRepo();
        }
    }
}
