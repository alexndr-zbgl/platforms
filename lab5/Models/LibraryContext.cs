using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System;
using Microsoft.EntityFrameworkCore;


namespace lab5.Models
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; } = null;
        public virtual DbSet<Book> Books { get; set; } = null;
        public virtual DbSet<Reader> Readers { get; set; } = null;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

    }
}
