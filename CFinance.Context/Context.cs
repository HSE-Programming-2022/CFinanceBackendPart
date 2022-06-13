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

        public CFinanceDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Host={Host};Port={Port};Database={DBName};Username={User};Password={Password}";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}