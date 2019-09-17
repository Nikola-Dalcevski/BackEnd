using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BicycleDbContex : DbContext
    {
        public BicycleDbContex(DbContextOptions<BicycleDbContex> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelbilder)
        {
            modelbilder.Entity<User>()
           .HasData(new User
           {
               Name = "Admin",
               Email = "Admin@gmail.com",
               Password = "123456",
               Phone = "111111111",
               Id = 1,
               Orders = null,
               Role = "BaseAdmin"


           });

            
            //base.OnModelCreating(modelbilder);

        }


    }
}
