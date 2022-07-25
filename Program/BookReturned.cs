using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class BookReturned : Book
    {
        public DateTime issueDate { get; set; }
        public DateTime returnDate { get; set; }
        public int userID { get; set; }

        public override string ToString()
        {
            return "[" + ID + " " + Title + " " + Author + " " + Publisher + " " + Edition + " " + Quantity + " " + issueDate + " " + returnDate + " " + userID + "]";

        }


    }

}
