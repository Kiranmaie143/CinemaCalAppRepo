using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaCalApp.Server.models
{
   
        public class ExpenseContext : DbContext
        {
            public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
            {
            }

            public DbSet<Expense> Expenses { get; set; }
        }
    
}
