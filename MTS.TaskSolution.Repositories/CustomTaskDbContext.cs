using Microsoft.EntityFrameworkCore;
using MTS.TaskSolution.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.TaskSolution.Repositories
{
    public class CustomTaskDbContext : DbContext
    {
        public CustomTaskDbContext(DbContextOptions<CustomTaskDbContext> options)
            : base(options)
        { }

        public DbSet<CustomTask> CustomTasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomTask>().ToTable("CustomTasks");

            modelBuilder.Entity<CustomTask>()
                .HasKey(task => task.Uid);
        }
    }
}
