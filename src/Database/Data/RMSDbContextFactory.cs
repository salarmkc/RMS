using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database.Data
{
    public class RmsDbContextFactory : IDesignTimeDbContextFactory<RmsDbContext>
    {
        public RmsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RmsDbContext>();
            builder.UseSqlServer(
                "Server=10.1.0.4;Database=RMSDB;User Id=sa;Password=Mn@6637310573;MultipleActiveResultSets=true");
            return new RmsDbContext(builder.Options);
        }

        public RmsDbContext CreateSaleAppDbContext(string arg)
        {
            var builder = new DbContextOptionsBuilder<RmsDbContext>();
            builder.UseSqlServer(
                "Server=10.0.1.11;Database=RMSDB;User Id=sa;Password=6637310573;MultipleActiveResultSets=true");
            return new RmsDbContext(builder.Options);
        }
    }
}
