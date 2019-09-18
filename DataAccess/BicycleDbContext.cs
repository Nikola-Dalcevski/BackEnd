using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
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
           var password = "123456";
            var hashPassword = sha256(password);
            

            modelbilder.Entity<User>()
           .HasData(new User
           {
               Name = "Admin",
               Email = "Admin@gmail.com",
               Password = hashPassword,
               Phone = "111111111",
               Id = 1,
               Orders = null,
               Role = "BaseAdmin"


           });

            
            //base.OnModelCreating(modelbilder);

        }

        public static string sha256(string password)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (byte theByte in bytes)
                {
                    sb.Append(theByte.ToString("x2"));
                }

                return sb.ToString();


            }
        }
    }
}
