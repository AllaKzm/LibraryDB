using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryDB.Models;

namespace LibraryDB.Data
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<IssuedBooks> IssuedBooks { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Publicist> Publicist { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               optionsBuilder.UseSqlite("Data Source=../Library.db");
    //      optionsBuilder.UseSqlServer("Data Source=DESKTOP-ECR2QDF\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.GenId)
                    .HasColumnName("GenID")
                    .HasColumnType("INT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("INT");

                entity.Property(e => e.PubYear)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.HasOne(d => d.Gen)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR(5)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("INT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("VARCHAR(11)");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenId);

                entity.Property(e => e.GenId)
                    .HasColumnName("GenID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.GenTitle)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<IssuedBooks>(entity =>
            {
                entity.HasKey(e => e.ReturnMark);

                entity.Property(e => e.ReturnMark).HasColumnType("CHAR (5)");

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("INT");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("INT");

                entity.Property(e => e.IssueDate)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.Property(e => e.ReadId)
                    .HasColumnName("ReadID")
                    .HasColumnType("INT");

                entity.Property(e => e.ReturnDate)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Read)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.ReadId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Demands)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Duties)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.PositionTitle)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Salary).HasColumnType("FLOAT");
            });

            modelBuilder.Entity<Publicist>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.PublicistTitle)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<Readers>(entity =>
            {
                entity.HasKey(e => e.ReadId);

                entity.Property(e => e.ReadId)
                    .HasColumnName("ReadID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DateTime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("VARCHAR(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
