using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.Auth
{
    public class UsernameOrPasswordWrongException : Exception
    {
        public UsernameOrPasswordWrongException() : base("Username or password is wrong")
        {
        }

        public UsernameOrPasswordWrongException(string? message) : base(message)
        {
        }
    }
}
