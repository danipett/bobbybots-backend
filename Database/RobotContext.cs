using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using RobotApp.Models;


namespace RobotApp.Database
{
    public class RobotContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RobotDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>()
                .Property(e => e.Categories)
                .HasConversion(
                    v => string.Join(", ",v),
                    v => v.Split(',',StringSplitOptions.RemoveEmptyEntries)
                );
        }
        public DbSet<Robot> Robots { get; set; }

    }
}