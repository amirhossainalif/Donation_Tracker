using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.Tables
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("Employee")]
        public int CommentedById { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Post Post { get; set; }
    }
}
