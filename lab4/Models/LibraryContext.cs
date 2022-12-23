using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System;
using Microsoft.EntityFrameworkCore;


namespace lab4.Models
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; } = null;
        public virtual DbSet<Book> Books { get; set; } = null;
        public virtual DbSet<Reader> Readers { get; set; } = null;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                optionsBuilder.UseSqlServer(connectionString: conf.GetConnectionString("Library"));
            }
        }
    }
}
