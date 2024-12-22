using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repos
{
    internal class Repo
    {
        internal Context db;
        internal Repo() { 
            db = new Context();
        }
    }
}
