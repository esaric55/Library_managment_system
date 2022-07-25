﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Book
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Edition { get; set; }
        public int Quantity { get; set; }
        

        public override string ToString()
        {
            return "[" + ID + " " + Title + " " + Author +" "+ Publisher +" "+ Edition +" "+ Quantity + "]";
          
        }





    }
}
