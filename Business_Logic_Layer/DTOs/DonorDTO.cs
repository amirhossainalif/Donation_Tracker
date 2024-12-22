using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class DonorDTO
    {
        public int Id { get; set; } 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Bank { get; set; }
        public string MobileBank { get; set; }
        public int DonationGoal { get; set; }
    }
}
