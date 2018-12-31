using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Data
{
    public static class RmsDbContextExtension
    {
        public static bool AllMigrationsApplied(this RmsDbContext rmsDbContext)
        {
            var applied = rmsDbContext.GetService<IHistoryRepository>().GetAppliedMigrations()
                .Select(m => m.MigrationId);
            var total = rmsDbContext.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this RmsDbContext rmsDbContext)
        {

        }
    }
}
