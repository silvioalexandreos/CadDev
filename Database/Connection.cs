using Database;
using Database.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CadFuncionario
{
    public class Connection : DbContext
    {
        public DbSet<Level> Niveis { get; set; }
        public DbSet<Developer> Desenvolvedores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-HU6IVHI5;Initial Catalog=CadDevDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=silvio;Password=saos@123;Database=caddev;");
        } 
    }
}