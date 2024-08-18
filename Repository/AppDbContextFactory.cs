using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Bu bağlantı dizesini manuel olarak buraya girin
            optionsBuilder.UseSqlServer("Server=DESKTOP-4027H88\\SQLEXPRESS;Database=ProjectDB;Trusted_Connection=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
