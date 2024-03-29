﻿using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

         public DbSet<Category> Categories { get; }
         public DbSet<Product> Products { get; }
         
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

             modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
         }
    }
}