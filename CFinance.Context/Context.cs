using CFinance.Context.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CFinance.Context
{
    public class CFinanceDbContext : DbContext
    {
        private static string Host = "ec2-54-77-40-202.eu-west-1.compute.amazonaws.com";
        private static string User = "crxcanuliilies";
        private static string DBName = "d8kdq0mmq73j21";
        private static string Port = "5432";
        private static string Password = "502af24ca12303d06ee70ebce9ae299815c93976ce1a8dd77aab1e725ba8d495";

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Cashflows> Cashflows { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<IncomeStatement> IncomeStatements { get; set; }
        public DbSet<BalanceSheet> BalanceSheets { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioCompany> PortfolioCompany { get; set; }


        public CFinanceDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioCompany>().HasKey(u => new
                {
                u.PortfolioID,
                u.Ticker
                }
            );

            modelBuilder.Entity<Company>()
                .HasOne(f => f.Cashflow)
                .WithOne(c => c.Company)
                .HasForeignKey<Cashflows>(c => c.Ticker);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Metrics)
                .WithOne(m => m.Company)
                .HasForeignKey<Metrics>(m => m.Ticker);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.IncomeStatement)
                .WithOne(m => m.Company)
                .HasForeignKey<IncomeStatement>(i => i.Ticker);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.BalanceSheet)
                .WithOne(b => b.Company)
                .HasForeignKey<BalanceSheet>(b => b.Ticker);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Portfolios)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID);

            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.Companies)
                .WithOne(p => p.portfolio)
                .HasForeignKey(p => p.PortfolioID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Host={Host};Port={Port};Database={DBName};Username={User};Password={Password}";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}