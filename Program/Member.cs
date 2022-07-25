using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

namespace Program
{
    public class Member : User
    {   
        
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email {get; set; }
       
       public virtual ICollection<BookIssued> Issued_books { get; set; }
       public virtual ICollection<BookReturned> Returned_books { get; set; }
        
       public override string ToString()
       {
            return "[" +Username + " " + Password + " " + FirstName + " " + LastName + " " + Address + " " + Email + " " +  "]";
       }
        
        
    }
}
