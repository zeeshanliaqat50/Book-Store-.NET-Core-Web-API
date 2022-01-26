using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        //here we can provide connection string or in the program.cs class with dbcontext registeration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionString");
        //    base.OnConfiguring(optionsBuilder);
        //}
        /*
         * 
         * Migration commands in Package console Manager
         * 1. add-migration init
         * 2. update-database
         */
    }

    
}

