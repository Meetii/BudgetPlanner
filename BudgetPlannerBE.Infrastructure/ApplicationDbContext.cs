using BudgetPlannerBE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //relations..
            //ONE-TO-MANY USER-EXPENSES
            builder.Entity<Expense>()
                .HasOne<User>(z => z.User)
                .WithMany(z => z.Expenses)
                .HasForeignKey(z => z.UserId);

            //ONE-TO-MANY USER-INCOMES
            builder.Entity<Income>()
                .HasOne<User>(z => z.User)
                .WithMany(z => z.Incomes)
                .HasForeignKey(z => z.UserId);


            //ONE-TO-MANY CATEGORY-EXPENSES
            builder.Entity<Expense>()
                .HasOne<Category>(z=> z.Category)
                .WithMany(z=>z.Expenses)
                .HasForeignKey(z=>z.CategoryId);

            //ONE-TO-MANY CATEGORY-INCOMES
            builder.Entity<Income>()
                .HasOne<Category>(z => z.Category)
                .WithMany(z => z.Incomes)
                .HasForeignKey(z => z.CategoryId);
        }

    }
}
