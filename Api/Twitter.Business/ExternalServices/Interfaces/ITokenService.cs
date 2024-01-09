using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
