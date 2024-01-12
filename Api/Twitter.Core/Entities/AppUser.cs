using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname {  get; set; }
        public DateTime BirthDate { get; set; }
        
        public IEnumerable<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        

    }
}
