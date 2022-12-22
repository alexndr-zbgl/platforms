using Microsoft.EntityFrameworkCore;

namespace lab2.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Reader> Readers { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.ReaderNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Reader)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Books_fk1");

                entity.HasOne(d => d.WriterNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Writer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Books_fk2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

