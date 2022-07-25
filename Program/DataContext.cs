using Microsoft.EntityFrameworkCore;


namespace Program
{

    public class DataContext : DbContext
    {
    
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssued> IssuedBooks { get; set; }
        public DbSet<BookReturned> ReturnedBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyLibrary; Integrated Security = True; Trusted_Connection =" + "true; MultipleActiveResultSets = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            var member = modelBuilder.Entity<Member>();
            var librarian = modelBuilder.Entity<Librarian>();
            var book = modelBuilder.Entity<Book>();
            var issuedbook = modelBuilder.Entity<BookIssued>();
            var returnedbook = modelBuilder.Entity<BookReturned>();

            user.ToTable("Users");
            member.ToTable("Members");
            librarian.ToTable("Librarians");
            book.ToTable("Books");
            issuedbook.ToTable("IssuedBooks");
            returnedbook.ToTable("ReturnedBooks");
           
            base.OnModelCreating(modelBuilder);
        }
    }

}

