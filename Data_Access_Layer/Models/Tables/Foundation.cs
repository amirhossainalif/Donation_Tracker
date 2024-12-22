using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.Tables
{
    public class Foundation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public string Phone { get; set; }
        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public string MobileBank { get; set; }
        public double balance { get; set; }

    }
}
