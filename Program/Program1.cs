using System;
using System.Collections.Generic;
using System.Linq;


namespace Program
{
   public class Program1
    {
        static User a, b, c, d, e;

        static Book book1, book2, book3, book4, book5, book6, book7;
        static DataContext context;
      

        public static void Main(string[] args)
        {

            CreateObjects();
            
            PopulateDatabase();
            ExecuteQueries();
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
        static void CreateObjects() {

            
            a = new Member {  Username = "Ante", Password = "ante1", FirstName = "Ante", LastName = "Antić", Email="ante4@gmail.com", Address="Zagrebačka 2" };
            b = new Member {  Username="Ivo", Password="ivo1", FirstName = "Ivo", LastName = "Ivić", Email = "ivo5@gmail.com", Address = "Vukovarska 4" };
            c = new Member {  Username="Klara", Password="klara1", FirstName = "Klara", LastName = "Klarić", Email = "klara6@gmail.com", Address = "Dubrovačka 6" };
            d = new Librarian { Username="Ana", Password="ana1", FirstName = "Ana", LastName = "Anić", Email = "ana4@gmail.com" };
            e = new Librarian { Username="Petar", Password="petar1", FirstName = "Petar", LastName = "Petrić", Email="petar8@gmail.com" };

            DateTime date1 = new DateTime(2022, 06, 22);
            DateTime date2 = new DateTime(2022, 07, 06);
            DateTime date3 = new DateTime(2022, 06, 26);
            DateTime date4 = new DateTime(2022, 07, 09);
            DateTime date5 = new DateTime(2022, 07, 15);
            DateTime date6 = new DateTime(2022, 07, 25);
            DateTime date7 = new DateTime(2022, 07, 17);
            DateTime date8 = new DateTime(2022, 07, 31);



            book1 = new BookIssued { Author = "Lav Nikolajevič Tolstoj", Title = "Ana Karenjina", Edition = 2004, Quantity = 10, Publisher = "Školska knjiga",
                userID = 2, issueDate = date1 , returnDate = date2 };
            book2 = new BookIssued{Author = "F.M.Dostojevski", Title = "Zločin i kazna", Edition = 2003, Quantity = 8, Publisher = "Školska knjiga",
                userID = 3, issueDate = date3, returnDate = date4};
            book3 = new BookIssued {Author = "Ivan Gundulić", Title = "Osman", Edition = 2005, Quantity = 12, Publisher = "Profil", userID = 1,
                issueDate = date1, returnDate = date2};
            book4 = new BookReturned { Author = "Antoine de Saint - Exupéry", Title = "Mali princ", Edition = 2006, Quantity = 5, Publisher = "Knjižara Ljevak",
            userID = 3, issueDate = date5, returnDate = date6};
            book5 = new BookReturned { Author = "Ernest Hemingway", Title = "Starac i more", Edition = 2002, Quantity = 3, Publisher = "Knjižara Ljevak",
             userID = 2, issueDate = date7, returnDate = date8};
            book6 = new Book { Author = "Homer", Title = "Ilijada", Edition = 2000, Quantity = 9, Publisher = "Profil"  };
            book7 = new Book { Author = "Sofoklo", Title = "Antigona", Edition = 2004, Quantity = 2, Publisher = "Profil" };


        }
        static void PrintFamily() { }
        static void PopulateDatabase()
        {
            context = new DataContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Users.Add(a);
            context.Users.Add(b);
            context.Users.Add(c);
            context.Users.Add(d);
            context.Users.Add(e);

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);



            int noRows = context.SaveChanges();
            Console.WriteLine("Number of rows affected: {0}", noRows);
            Console.WriteLine("{0} Rows affected.", noRows);
        }
        static void ExecuteQueries() {
            Console.WriteLine("Queries ....");
            var members = from m in context.Members
                         // where m.ID > 1
                          select m;
            
            foreach (Member m in members) Console.WriteLine(m);
            Console.WriteLine("-----");
       
           

        }
    }
}