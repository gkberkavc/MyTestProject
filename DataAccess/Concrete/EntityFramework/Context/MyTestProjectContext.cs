using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class MyTestProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GOKBERK;Database=MyTestProject;Trusted_Connection=true;");
        }

        public DbSet<Products> Product { get; set; }
        public DbSet<Users> User { get; set; }
    }


}
