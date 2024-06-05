using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace de
{
    public static class UserSession
    {
        public static string _login;

        public static string CurrentUser
        {
            get { return _login; } 
            set { _login = value; }
        }
    }
}
