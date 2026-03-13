using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DashBoard.Models;

namespace DashBoard.Data
{
    public class DashBoardContext : DbContext
    {
        public DashBoardContext (DbContextOptions<DashBoardContext> options)
            : base(options)
        {
        }

        public DbSet<DashBoard.Models.Employee> Employee { get; set; } = default!;
    }
}
