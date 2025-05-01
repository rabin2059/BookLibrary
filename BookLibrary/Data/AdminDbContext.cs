using System;
using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data;

public class AdminDbContext: DbContext
{

    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }

}
