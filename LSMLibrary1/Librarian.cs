using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LSMLibrary1
{
    public class Librarian
    {
        
     public int ID { get; set; }
 
     [StringLength(256)]
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public DateTime BirthDate { get; set; }
     public string Email { get; set; }
     public override string ToString() { 
     return "(" + ID + " " + FirstName + " " + LastName + " " + BirthDate + " " + Email + ")"; 
     }
   
     
    
    }
 }
    
