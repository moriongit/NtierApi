using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Dtos.CommentDtos
{
    public class CommentListItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ParentCommentId { get; set; }
        public DateTime CreatedTime { get; set; }
        //public AppUserDtos.AppUserInPostItemDto AppUser {get;set;}
    }
}
