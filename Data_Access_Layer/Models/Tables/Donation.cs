using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.Tables
{
    public class Donation
    {
        public int Id { get; set; }
        [ForeignKey("foundation")]
        public int F_Id { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        [StringLength(50)]
        public string Donation_Mediam { get; set; }
        [Required]
        public string date { get; set; }
        [ForeignKey("donor")]
        public int D_id { get; set; }
        public virtual Donor donor { get; set; }
        public virtual Foundation foundation { get; set; }
    }
}
