using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context : db tabloları ile proje classlarını ilişkilendirmek
    //Bizim yapmaya çalıştığımız database tabloları ile classları bağlamak.
    public class NorthwindContext : DbContext  //DbContext bizim asıl contextimizdir.EntityFramework paketi ile geliyor.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bu method sayesinde projemin hangi veritabanı ile ilişkili olduğunu belirtiyorum.
        { 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //sql kullanacağımızı belirtiyorum.string ifadenin başında @ işareti varsa \'ı normal \ olarak algılaması anlamına gelir. Normalde (localdb)\MSSQLLocalDB olarak yazılan yerde ip adresi yazılır ancak local veritabanından çektiğim için böyle yazdıım.
        }

        public DbSet<Product> Products { get; set; }   //Benim product nesnemi veritabanındaki products ile bağla demek istiyorum.Hangi classım hangi tabloya denk geliyor.
        public DbSet<Category> Categories { get; set; } //Entitiesteki classlar veritabanındaki tablolar ile ilişkilendirilmiş oldu.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
