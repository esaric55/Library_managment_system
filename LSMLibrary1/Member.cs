using System;
using System.Collections.Generic;
using System.Text;

namespace LSMLibrary1
{
    public class Member
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return "[" + ID + " " + FirstName + " " + LastName + " " + Address + " " + Email + " " + RegistrationDate + " " + ExpirationDate + "]";
        }
        public void PrintMembers()
        {
            Console.WriteLine("{0}'s members: ", FirstName + LastName);
            foreach (Member m in Members) Console.WriteLine("\t" + m);
        }


    }
}
