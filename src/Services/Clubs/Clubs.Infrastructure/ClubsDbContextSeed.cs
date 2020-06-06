

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clubs.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Clubs.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {

        public static async Task SeedAsync(ClubsContext context)
        {
            
            if(!context.Clubs.Any())
            {
                var RandoxIT = new Club() {Name = "Randox IT"};
                var Players = new List<Player>();
                var Sean = new Player() {FirstName = "Sean", LastName = "Rafferty", Email = "srafferty89@gmail.com", Club = RandoxIT, Rating = 50};
                Players.Add(Sean);
                var Francy = new Player() {FirstName = "Francy", LastName = "Donald", Email = "francy.donald@randox.com", Club = RandoxIT, Rating = 85};
                Players.Add(Francy);
                var Andy = new Player() {FirstName = "Andy", LastName = "Williamson", Email = "andy@randox.com", Club = RandoxIT, Rating = 72};
                Players.Add(Andy);
                var Ross = new Player() {FirstName = "Ross", LastName = "Bratton", Email = "ross@randox.com", Club = RandoxIT, Rating = 65};
                Players.Add(Ross);
                var Conor = new Player() {FirstName = "Conor", LastName = "Devlin", Email = "conor@randox.com", Club = RandoxIT, Rating = 65};
                Players.Add(Conor);
                var David = new Player() {FirstName = "David", LastName = "McCrory", Email = "david@randox.com", Club = RandoxIT, Rating = 70};
                Players.Add(David);
                var Steve = new Player() {FirstName = "Steve", LastName = "Kennedy", Email = "steve@randox.com", Club = RandoxIT, Rating = 70};
                Players.Add(Steve);
                var Mike = new Player() {FirstName = "Mike", LastName = "Hayes", Email = "mike@randox.com", Club = RandoxIT, Rating = 78};
                Players.Add(Mike);
                var Oran = new Player() {FirstName = "Oran", LastName = "McMenamin", Email = "Oran@randox.com", Club = RandoxIT, Rating = 70};
                Players.Add(Oran);
                var Darren = new Player() {FirstName = "Darren", LastName = "Tweed", Email = "Darren@hotmail.com", Club = RandoxIT, Rating = 68};
                Players.Add(Darren);
                RandoxIT.Players = Players;
                context.Clubs.Add(RandoxIT);


                var RandoxEng = new Club() {Name = "Randox Engineering"};
                CreatePlayerList(RandoxEng);
                context.Clubs.Add(RandoxEng);

                var Club2 = new Club() {Name = "Club 2"};
                CreatePlayerList(Club2);
                context.Clubs.Add(Club2);

                var Club3 = new Club() {Name = "Club 3"};
                CreatePlayerList(Club3);
                context.Clubs.Add(Club3);

                await context.SaveChangesAsync
                ();
            }
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

        #region Players

        private static void CreatePlayerList(Club club)
        {
            RandomNameGenerator gen = new RandomNameGenerator();
            
            int randomNumber = gen.GenerateRandomNumber(1, 25);

            club.Players = new List<Player>();

            for (int i = 0; i < randomNumber; ++i)
            {
                club.Players.Add(new Player{FirstName = gen.getRandomFirstName(), LastName = gen.getRandomLastName(), Rating = gen.GenerateRandomNumber(), Club = club, Email = "Unknown"});
            }
        }

        #endregion
    }
}