using GrpcService.Models;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Context
{
    
        public class DbApplicationContext : DbContext
        {
            public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options) { }

            public DbSet<Book> Books { get; set; }
            public DbSet<BookStudentOrder> BookStudentOrders { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                Seed(builder);
                base.OnModelCreating(builder);
            }
            private void Seed(ModelBuilder builder)
            {
                builder
                    .Entity<BookStudentOrder>()
                    .HasKey(x => new { x.StudentId, x.BookId });

                builder
                    .Entity<BookStudentOrder>()
                    .HasOne(x => x.Book)
                    .WithMany(y => y.BookStudentOrders)
                    .HasForeignKey(x => x.BookId);

                builder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Author = "sumit",
                        Price = 200,
                        Subject = "How to code",
                        Title = "C#",
                        IsAvailable = true,
                        StudyProgrammeId = 1
                    },
                       new Book
                       {
                           Id = 2,
                           Author = "christoffer",
                           Price = 300,
                           Subject = "System integration",
                           Title = "Soa",
                           IsAvailable = true,
                           StudyProgrammeId = 1
                       },

                        new Book
                        {
                            Id = 3,
                            Author = "Alham",
                            Price = 200,
                            Subject = "May he be with u",
                            Title = "Guide to Heaven",
                            IsAvailable = true,
                            StudyProgrammeId = 2
                        },
                        new Book
                        {
                            Id = 4,
                            Author = "Praktik soon",
                            Price = 350,
                            Subject = "How to ace praktik",
                            Title = "Praktik for gods",
                            IsAvailable = true,
                            StudyProgrammeId = 3
                        });
            }
        }
    }

