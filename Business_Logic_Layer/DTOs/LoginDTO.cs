using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
