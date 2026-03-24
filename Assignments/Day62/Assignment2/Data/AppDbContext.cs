using Microsoft.EntityFrameworkCore;
using Day62.Assignment2.Models;

namespace Day62.Assignment2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Loan> Loans { get; set; }
}