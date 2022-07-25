using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Program
{
    public abstract class User
    {

        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

       public virtual ICollection<Member> Members { get; set; }
       public virtual ICollection<Librarian> Librarians { get; set; }
        
        public override string ToString()
        {
            return "[" + Username + " " + Password + "]";
        }

       // public void PrintMembers()
        //{
         //  Console.WriteLine("{0}'s members: ", Username);
          // foreach (Member m in Members) Console.WriteLine("\t" + m);
        //}


    }
}
