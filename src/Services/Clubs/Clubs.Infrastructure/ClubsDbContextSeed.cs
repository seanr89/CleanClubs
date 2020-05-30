

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Clubs.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {

        public static async Task SeedSampleDataAsync(ClubsContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://github.com/dotnet-architecture/eShopOnContainers/blob/43fe719e98bb7e004c697d5724a975f5ecb2191b/src/Services/Identity/Identity.API/Data/ApplicationDbContextSeed.cs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public async static Task SeedAsyncFromFile(ClubsContext context, IWebHostEnvironment env)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}