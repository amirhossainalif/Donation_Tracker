using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.Tables
{
    public class Token
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        [ForeignKey("Foundation")]
        public int F_Id { get; set; }
        public virtual Foundation Foundation { get; set; }
        [ForeignKey("Employee")]
        public int E_Id { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Donor")]
        public int D_Id { get; set; }
        public virtual Donor Donor { get; set; }
        [Required]
        public string User { get; set; }
    }
}
