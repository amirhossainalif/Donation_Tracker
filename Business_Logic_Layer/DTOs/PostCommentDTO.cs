using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class PostCommentDTO : PostDTO
    {
        public List<CommentDTO> comments {  get; set; }
        public PostCommentDTO() { 
            comments = new List<CommentDTO>();
        }
    }
}
