using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.CommentDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface ICommentService
    {
        //Task Create();
        
         IEnumerable<CommentListItemDto> GetAll();
        //Task Delete(int id);
        //Task SoftDelete(int id);
        //Task ReverseSoftDelete(int id);

        //Task React(int id);  //ReactionTypes type)
    }
}
