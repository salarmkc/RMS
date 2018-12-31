using ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Data
{
    public class RmsDbContextSeedData
    {


        public static async Task EnsureSeedDataAsync(RmsDbContext rmsDbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!rmsDbContext.Users.Any())
                {
                    var user = new User()
                    {

                    };
                    rmsDbContext.Add(user);
                    await rmsDbContext.SaveChangesAsync();
                }

                var dataText = System.IO.File.ReadAllText(@"docs\Countries.json");
                if (!rmsDbContext.Countries.Any())
                {
                    var countries = JsonConvert.DeserializeObject(dataText);

                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<RmsDbContextSeedData>();
                    log.LogError(ex.Message);
                    await EnsureSeedDataAsync(rmsDbContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
