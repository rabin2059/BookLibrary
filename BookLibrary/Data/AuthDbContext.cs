using System;
using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data;

public class AuthDbContext : DbContext
{
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        
}
