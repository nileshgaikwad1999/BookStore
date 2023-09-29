using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public partial class booksAppContext : DbContext
    {
        public booksAppContext()
        {
        }

        public booksAppContext(DbContextOptions<booksAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        public DbSet<BooksDetails> booksDetails { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .HasColumnName("image")
                    .IsFixedLength();

                entity.Property(e => e.IsBn)
                    .HasMaxLength(50)
                    .HasColumnName("IsBN");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Summary)
                    .HasMaxLength(250)
                    .HasColumnName("summary");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Book_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
