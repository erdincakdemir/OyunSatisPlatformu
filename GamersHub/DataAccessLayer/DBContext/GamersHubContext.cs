using DataAccessLayer.Mappings;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DBContext
{
    public class GamersHubContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public static readonly string connString = @"Server=.\SQLEXPRESS;Database=GamersHubDB;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameMap());
            builder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(builder);
        }


        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
