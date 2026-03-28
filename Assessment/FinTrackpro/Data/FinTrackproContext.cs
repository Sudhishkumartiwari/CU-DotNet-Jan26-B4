using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrackpro.Models;

namespace FinTrackpro.Data
{
    public class FinTrackproContext : DbContext
    {
        public FinTrackproContext (DbContextOptions<FinTrackproContext> options)
            : base(options)
        {
        }

       // public DbSet<FinTrackpro.Models.Transaction> Transaction { get; set; } = default!;
        public DbSet<Account> Account { get; set; } = default!;
        public DbSet<Transaction> Transaction { get; set; } = default!;
    }
}
