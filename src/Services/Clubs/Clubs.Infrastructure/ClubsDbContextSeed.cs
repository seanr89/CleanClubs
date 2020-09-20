

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
            if (!context.Clubs.Any())
            {
                var RandoxIT = new Club() { Name = "Rdox IT", Creator = "Sean Rafferty" };
                var Members = new List<Member>();
                var Sean = new Member() { FirstName = "Sean", LastName = "Rafferty", Email = "srafferty89@gmail.com", Club = RandoxIT, Rating = 50.2 };
                Members.Add(Sean);
                var Sean2 = new Member() { FirstName = "Sean", LastName = "Personal", Email = "srafferty89@gmail.com", Club = RandoxIT, Rating = 45.1 };
                Members.Add(Sean2);
                var SeanWork = new Member() { FirstName = "Sean", LastName = "Rdx", Email = "sean.rafferty@randox.com", Club = RandoxIT, Rating = 99.9 };
                Members.Add(SeanWork);
                var Francy = new Member() { FirstName = "Francy", LastName = "Donald", Email = "francy.donald@randox.com", Club = RandoxIT, Rating = 85 };
                Members.Add(Francy);
                var Andy = new Member() { FirstName = "Andy", LastName = "Williamson", Email = "andy@randox.com", Club = RandoxIT, Rating = 72 };
                Members.Add(Andy);
                var Ross = new Member() { FirstName = "Ross", LastName = "Bratton", Email = "ross@randox.com", Club = RandoxIT, Rating = 65 };
                Members.Add(Ross);
                var Conor = new Member() { FirstName = "Conor", LastName = "Devlin", Email = "conor@randox.com", Club = RandoxIT, Rating = 65 };
                Members.Add(Conor);
                var David = new Member() { FirstName = "David", LastName = "McCrory", Email = "david@randox.com", Club = RandoxIT, Rating = 70 };
                Members.Add(David);
                var Steve = new Member() { FirstName = "Steve", LastName = "Kennedy", Email = "steve@randox.com", Club = RandoxIT, Rating = 70 };
                Members.Add(Steve);
                var Mike = new Member() { FirstName = "Mike", LastName = "Hayes", Email = "mike@randox.com", Club = RandoxIT, Rating = 78 };
                Members.Add(Mike);
                var Oran = new Member() { FirstName = "Oran", LastName = "McMenamin", Email = "Oran@randox.com", Club = RandoxIT, Rating = 70 };
                Members.Add(Oran);
                var Darren = new Member() { FirstName = "Darren", LastName = "Tweed", Email = "Darren@hotmail.com", Club = RandoxIT, Rating = 63 };
                Members.Add(Darren);
                var Mark = new Member() { FirstName = "Mark", LastName = "Latten", Email = "mark@randox.com", Club = RandoxIT, Rating = 64 };
                Members.Add(Mark);
                var Ivan = new Member() { FirstName = "Ivan", LastName = "Mc", Email = "ivan@randox.com", Club = RandoxIT, Rating = 68 };
                Members.Add(Ivan);
                var Kelso = new Member() { FirstName = "Steven", LastName = "Kelso", Email = "kelso@randox.com", Club = RandoxIT, Rating = 71 };
                Members.Add(Kelso);
                var Frazer = new Member() { FirstName = "Andrew", LastName = "Frazer", Email = "Frazer@randox.com", Club = RandoxIT, Rating = 72 };
                Members.Add(Frazer);
                var Cormac = new Member() { FirstName = "Cormac", LastName = "Byrne", Email = "Cormac@randox.com", Club = RandoxIT, Rating = 66 };
                Members.Add(Cormac);
                var JJ = new Member() { FirstName = "JJ", LastName = "Eng", Email = "JJ@randox.com", Club = RandoxIT, Rating = 61 };
                Members.Add(JJ);
                var Dean = new Member() { FirstName = "Dean", LastName = "Mc", Email = "sean.rafferty@randox.com", Club = RandoxIT, Rating = 99.9, Active = false };
                Members.Add(Dean);
                RandoxIT.Members = Members;
                context.Clubs.Add(RandoxIT);

                var RandoxEng = new Club() { Name = "Rdox Engineering" };
                CreateMemberList(RandoxEng);
                context.Clubs.Add(RandoxEng);

                for (int i = 2; i <= 55; i++)
                {
                    var club = new Club() { Name = $"Club {i}" };
                    CreateMemberList(club);
                    context.Clubs.Add(club);
                }

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// https://github.com/dotnet-architecture/eShopOnContainers/blob/43fe719e98bb7e004c697d5724a975f5ecb2191b/src/Services/Identity/Identity.API/Data/ApplicationDbContextSeed.cs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        // public async static Task SeedAsyncFromFile(ClubsContext context, IWebHostEnvironment env)
        // {
        //     try
        //     {

        //     }
        //     catch (Exception ex)
        //     {

        //     }
        // }

        #region Members

        private static void CreateMemberList(Club club)
        {
            RandomNameGenerator gen = new RandomNameGenerator();

            int randomNumber = gen.GenerateRandomNumber(12, 46);

            club.Members = new List<Member>();

            for (int i = 0; i < randomNumber; ++i)
            {
                club.Members.Add(new Member
                {
                    FirstName = gen.getRandomFirstName(),
                    LastName = gen.getRandomLastName(),
                    Rating = gen.GenerateRandomNumber(),
                    Club = club,
                    Email = "Unknown"
                });
            }
        }

        #endregion
    }
}