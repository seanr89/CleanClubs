

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
            await SeedClubsAndMembers(context);
            await SeedLocations(context);
        }

        private async static Task SeedClubsAndMembers(ClubsContext context)
        {
            if (!context.Clubs.Any())
            {
                var RandoxIT = new Club() { Name = "Rdox IT", Creator = "Sean Rafferty" };
                var Members = new List<Member>();
                var Sean = new Member("Sean", "Rafferty", "sean.rafferty@randox.com", 50.2) { Club = RandoxIT };
                Members.Add(Sean);
                var Sean2 = new Member("Sean", "Personal", "srafferty89@gmail.com", 45.1) { Club = RandoxIT };
                Members.Add(Sean2);
                var SeanWork = new Member("Sean", "Rdx", "sean.rafferty@randox.com", 99.9) { Club = RandoxIT };
                Members.Add(SeanWork);
                var Francy = new Member("Francy", "Donald", "francis.donald@randox.com", 85) { Club = RandoxIT };
                Members.Add(Francy);
                var Andy = new Member("Andy", "Williamson", "andy@randox.com", 72.1) { Club = RandoxIT };
                Members.Add(Andy);
                var Ross = new Member("Ross", "Bratton", "ross.bratton@randox.com", 65) { Club = RandoxIT };
                Members.Add(Ross);
                var Conor = new Member("Conor", "Devlin", "conor.devlin@randox.com", 65) { Club = RandoxIT };
                Members.Add(Conor);
                var David = new Member("David", "McCrory", "david@randox.com", 70) { Club = RandoxIT };
                Members.Add(David);
                var Steve = new Member("Steve", "Kennedy", "steve@randox.com", 70) { Club = RandoxIT };
                Members.Add(Steve);
                var Mike = new Member("Mike", "Hayes", "mike@randox.com", 78) { Club = RandoxIT };
                Members.Add(Mike);
                var Oran = new Member("Oran", "McMenamin", "Oran@randox.com", 70) { Club = RandoxIT };
                Members.Add(Oran);
                var Darren = new Member("Darren", "Tweed", "Darren@hotmail.com", 63) { Club = RandoxIT };
                Members.Add(Darren);
                var Mark = new Member("Mark", "Latten", "mark@randox.com", 64) { Club = RandoxIT };
                Members.Add(Mark);
                var MarkTwo = new Member("Mark", "Lutton", "marklutton@randox.com", 64) { Club = RandoxIT };
                Members.Add(MarkTwo);
                var Ivan = new Member("Ivan", "Mc", "ivan@randox.com", 68) { Club = RandoxIT };
                Members.Add(Ivan);
                var Kelso = new Member("Steven", "Kelso", "kelso@randox.com", 71) { Club = RandoxIT };
                Members.Add(Kelso);
                var Frazer = new Member("Andrew", "Frazer", "Frazer@randox.com", 72) { Club = RandoxIT };
                Members.Add(Frazer);
                var Cormac = new Member("Cormac", "Byrne", "Cormac@randox.com", 66) { Club = RandoxIT };
                Members.Add(Cormac);
                var JJ = new Member("JJ", "Eng", "JJ@randox.com", 61) { Club = RandoxIT };
                Members.Add(JJ);
                var Dean = new Member("Dean", "Mc", "sean.rafferty@randox.com", 45.6) { Club = RandoxIT };
                Members.Add(Dean);
                var Ryan = new Member("Ryan", "Gavin", "ryang@randox.com", 86.1) { Club = RandoxIT };
                Members.Add(Ryan);
                var Iniaki = new Member("Iniaki", "McKearny", "Iniaki@randox.com", 75.0) { Club = RandoxIT };
                Members.Add(Iniaki);
                var JamesD = new Member("James", "Davidson", "JamesD@randox.com", 59.0) { Club = RandoxIT };
                Members.Add(JamesD);
                var StuartG = new Member("Stuart", "Gray", "Stuartg@randox.com", 87.0) { Club = RandoxIT };
                Members.Add(StuartG);
                var William = new Member("William", "Lawrence", "William@randox.com", 79.0) { Club = RandoxIT };
                Members.Add(William);
                var Pierce = new Member("Pierce", "Slaney", "pierces@randox.com", 62.0) { Club = RandoxIT };
                Members.Add(Pierce);
                var Michael = new Member("Michael", "Crampsey", "mciahelc@randox.com", 50.0) { Club = RandoxIT };
                Members.Add(Michael);
                RandoxIT.Members = Members;
                context.Clubs.Add(RandoxIT);

                var RandoxEng = new Club() { Name = "Rdox Engineering" };
                CreateMemberList(RandoxEng);
                context.Clubs.Add(RandoxEng);

                for (int i = 2; i <= 105; i++)
                {
                    var club = new Club() { Name = $"Club {i}" };
                    CreateMemberList(club);
                    context.Clubs.Add(club);
                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
        }

        private async static Task SeedLocations(ClubsContext context)
        {
            if (!context.Locations.Any())
            {
                var allenPark = new Location("Allen Park", "45 Castle Rd", "Antrim", "BT41 4NA", true,
                    "https://www.tobermore.co.uk/professional/project/allen-park-leisure-centre/");
                context.Locations.Add(allenPark);

                var armaghL = new Location("Orchard Leisure Centre", "37-39 Folly Ln", "Armagh", "BT60 1AT", true,
                    "https://getactiveabc.com/facility/orchard-leisure-centre/");
                context.Locations.Add(armaghL);

                var antrimForum = new Location("Antrim Forum", "50 Stiles Way", "Antrim", "BT41 2UB", true,
                    "https://antrimandnewtownabbey.gov.uk/reopening-of-our-leisure-centres/");
                context.Locations.Add(antrimForum);

                await context.SaveChangesAsync();
            }
        }

        #region Private Methods

        private static void CreateMemberList(Club club)
        {
            RandomNameGenerator gen = new RandomNameGenerator();

            int randomNumber = gen.GenerateRandomNumber(12, 56);

            club.Members = new List<Member>();

            for (int i = 0; i < randomNumber; ++i)
            {
                club.Members.Add(new Member(gen.getRandomFirstName(), gen.getRandomLastName(), "Unknown", gen.GenerateRandomNumber())
                {
                    Club = club
                });
            }
        }

        #endregion
    }
}