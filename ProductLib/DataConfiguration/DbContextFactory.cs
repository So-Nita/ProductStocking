using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductLib.DataConfiguration
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ProductContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ProductStocking;User Id=sa;Password=Mypassword;encrypt=true;trustservercertificate=true;");
            return new ProductContext(dbContextOptionsBuilder.Options);
        }
    }
}

