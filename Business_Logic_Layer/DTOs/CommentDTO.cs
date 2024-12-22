using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime date { get; set; }
        public int CommentedById { get; set; }
        public int PostId { get; set; }
    }
}
