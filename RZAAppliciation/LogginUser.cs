using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZAAppliciation
{
    public class LogginUser
    {

        // Values only have the get; modifer to make it read-only.
        public string Username { get; }
        public string Password {  get; }
        public Boolean TwoFA { get;}
        public LogginUser(string username, string password, bool twoFA)
        {
            Username = username;
            Password = password;
            TwoFA = twoFA;
        }

        public LogginUser()
        {
        }
    }
}
