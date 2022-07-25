using System;
using System.Collections.Generic;
using System.Text;

namespace LSMLibrary1
{
    public abstract class User
    {
        public string Username { get; set; }
        
        public int Password { get; set; }
       
        public override string ToString()
        {
            return "[" + Username + " " + Password + "]";
        }

        public bool Login(string username, int password, bool isPersistent) { }
            
        
        }
    }
}
