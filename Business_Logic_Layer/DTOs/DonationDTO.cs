using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public int F_Id { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        [StringLength(50)]
        public string Donation_Mediam { get; set; }
        [Required]
        public string date { get; set; }
        public int D_ID { get; set; }
    }
}
