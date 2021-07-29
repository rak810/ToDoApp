using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp
{
    public class ToDoDbContext : DbContext
    {
        
        public DbSet<ToDo> ToDos { get; set; }
        public string DbPath { get; private set; }

        public ToDoDbContext()
        {
            
            if(OperatingSystem.IsWindows())
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                string v = $"{path}{System.IO.Path.DirectorySeparatorChar}tasks.db";
                DbPath = v;
                
            }
            else 
            {
                // Nix operations
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                        .Property(td => td.Title)
                        .IsRequired()
                        .HasMaxLength(250);
            modelBuilder.Entity<ToDo>()
                        .Property(td => td.Date)
                        .IsRequired();
            modelBuilder.Entity<ToDo>()
                        .Property(td => td.Note)
                        .HasMaxLength(500);
        }


    }

}