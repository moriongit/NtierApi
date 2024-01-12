using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        
        public string Content { get; set; }
        public int ParentCommentId { get; set; }
        

    }
}
