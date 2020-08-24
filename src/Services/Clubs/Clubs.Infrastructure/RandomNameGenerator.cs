
using System;

namespace Clubs.Infrastructure
{
     public class RandomNameGenerator
    {
        string[] _lastName = new string[] { "Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast", "Deitz", "Dewalt", "Ebner", "Frick", "Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki",
        "Mccord", "McCormack", "Miller", "Myers", "Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pettigrew", "Quinn", "Quizoz", "Ramachandran", "Resnick", "Sagar", "Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling",
         "Soukup", "Soulis", "Stahl", "Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader", "Vail", "Valente", "Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss",
          "Woo", "Yang", "Yates", "Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon", "Chambers", "Chapman", "Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan", "Duffman",
          "Eastman", "Ferro", "Ferry", "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap", "Jenson", "Johnson", "Johnsen", "Jones", "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde", "Lulloff", "Maki",
           "Martin", "McGinnis", "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson", "Ostrander", "Reardon", "Reyes", "Rice", "Ripka", "Roberts", "Rogers", "Root", "Sandstrom", "Sawyer", "Schmitt", "Schutz", "Schuster", "Tapia", "Thompson", "Tiernan", "Tisler" };
        string[] _firstnames = new string[] {"Aaran", "Aaron", "Aarron", "Abraham", "Abu", "Adam", "Adrian",
                "Alastair", "Albert", "Albie", "Alex", "Alexander", "Alfred", "Alistair", "Alistar", "Alister", "Allesandro", "Allister", "Ally", "Andrei", "Andrew", "Andy", "Anthony", "Anthony-John", "Antoine",
                "Aodhan", "Aonghus", "Arann", "Archibald", "Archie", "Arnold", "Arthur", "Artur", "Arya", "Ashtyn", "Ashwin", "Aslam", "Asrar", "Austin", 
                "Bailey", "Bailie", "Benedict", "Benjamin", "Benjamyn", "Benji", "Bennett", "Benny", "Bernard", "Bertie", "Bevin", "Bill", "Billy","Blaine", "Blair", "Blake", "Bob", "Bobby", "Brad", "Bradan", "Braden", "Bradley",
                 "Brady", "Bradyn", "Braeden", "Braiden", "Brajan", "Brandan", "Branden", "Brandon", "Brannan", "Brayden", "Braydon","Brendan", "Brendon", "Brett", "Brian", "Brodi", "Brody",
                 "Brogan", "Broghan", "Brooke", "Brooklyn", "Bruce", "Bruin", "Bruno", "Bryan", "Bryce", "Cahlum", "Cailin",
                 "Callum", "Callun", "Callyn", "Calum", "Calum-James", "Calvin", "Cambell", "Camerin", "Cameron", "Campbell",
                 "Caolain", "Caolan", "Carl", "Carlo", "Carlos", "Casey", "Casper", "Cassy", "Cathal", "Cator", "Cavan", "Cayden",
                 "Charles", "Charley", "Charlie", "Chevy", "Chi", "Chin", "Chris", "Christopher", "Christopher-Lee", "Christy", "Cian", "Ciaran", "Cieran",
                 "Cillian", "Cillin", "Cinar", "CJ", "Clark", "Clarke", "Clayton", "Clement", "Clifford", "Clyde", "Cobain",
                 "Cobie", "Coby", "Codey", "Codi", "Codie", "Cody", "Cody-Lee", "Coel", "Cohan", "Cohen", "Colby", "Cole", "Colin", "Colm", "Colt", "Colton", "Conal", "Conall", "Conan",
                 "Conlan", "Conley", "Conli", "Connel", "Connell", "Conner", "Connolly", "Connor", "Connor-David", "Conor", "Conrad", "Cooper", "Coray", "Corben",
                 "Cormac", "Cory", "Cosmo", "Craig", "Craig-James", "Cristian", "Damian", "Damien", "Damon", "Dan", "Danar", "Dane", "Danial", "Daniel", "Daniil", "Danny", "Dante",
                 "Darius", "Darl", "Darn", "Darrach", "Darragh", "Darrel", "Darrell", "Darren", "Darrie", "Darrius", "Darroch", "Darryl", "Darryn", "Darwyn", "Daryl", "David",
                 "Deacon", "Deagan", "Dean", "Deano", "Decklan", "Declan", "Deegan", "Deelan", "Del", "Demetrius", "Denis", "Deniss", "Dennan", "Dennin", "Dennis",
                 "Devyn", "Dex", "Dexter", "Dhani", "Dharam", "Dhavid", "Dhyia", "Diarmaid", "Diarmid", "Diarmuid", "Didier", "Diego", "Digby", "Dillan", "Dillon", "Dimitri", "Dolan", "Domhnall",
                  "Dominic", "Dominick", "Dominik", "Donald", "Donnacha", "Donnie", "Dorian", "Dougal", "Douglas", "Drew", "Duncan", "Duriel", "Dustin", "Dylan",
                  "Eamon", "Eamonn", "Ed", "Eddie", "Eden", "Ediomi", "Edison", "Eduardo","Edward",
                 "Eli", "Elias", "Elijah", "Elliot", "Elliott", "Ellis", "Emanuel", "Emerson", "Enrico",
                 "Enrique", "Enzo", "Eoghain", "Eoghan", "Eoin", "Eric", "Erik",
                 "Esteban", "Ethan", "Etienne", "Euan", "Eugene", "Evan", "Evann", "Ewan", "Ezekiel", "Ezra", "Fabian",
                  "Felix", "Fergal", "Fergie", "Fergus", "Filippo", "Findlay", "Finlay", "Finley", "Finn", "Finnan", "Finnlay", "Fintan", "Fletcher", "Flint", "Flyn",
                  "Flynn", "Francesco", "Francis", "Francisco", "Franco", "Frank", "Frankie", "Franklin", "Fraser", "Frazer", "Fred", "Freddie", "Frederick", "Fynn", "Gabriel", "Gareth", "Garren", "Garrett", "Garry", "Gary", "Geoff", "Geoffrey",
                  "Geordan", "Geordie", "George", "Georgia", "Georgy", "Gerard","Giacomo", "Gian", "Giancarlo", "Gianluca", "Glen", "Glenn", "Gordon", "Grady", "Graeme", "Graham", "Grahame", "Grant", "Grayson",
                  "Greg", "Gregor", "Gregory", "Griffin", "Guillaume", "Gus", "Gustav", "Hamish",
                  "Haris", "Harish", "Harley", "Harman", "Harnek", "Harold", "Harper", "Harrington", "Harris", "Harrison", "Harry", "Harvey", "Hayden",
                  "Hector", "Henry", "Herbert", "Heyden", "Hope", "Hopkin", "Hugh", "Hugo", "Hunter", "Iain", "Ian", "Irvin", "Irvine", "Isa", "Isaa", "Isaac",
                  "Jack", "Jacki", "Jackie", "Jack-James", "Jackson", "Jacky", "Jacob", "Jacques", "Jaden", "Jadon", "Jadyn", "Jae", "Jagat", "Jago", "Jaheim", "Jahid", "Jai", "Jaime", "Jak", "Jake", "Jakey", "Jakob", "Jamaal", "Jamal", "James", "James-Paul", "Jamey", "Jamie", "Jan", "Jaosha", "Jardine", "Jared", "Jason", "Jasper", "Jay", "Jaydan", "Jayden", "Jed", "Jedidiah", "Jeffrey", "Jensen", "Jenson", "Jeremy", "Jerome", "Jeronimo", "Jerrick", "Jerry", "Jesse",
                   "Jimmy", "JJ", "Joaquin", "Joash", "Jock", "Jody", "Joe", "Joeddy", "Joel", "Joey", "Joey-Jack", "Johann", "Johannes", "Johansson", "John", "Johnathan", "Johndean", "Johnjay", "John-Michael", "Johnnie", "Johnny", "Johnpaul", "John-Paul", "John-Scott", "Johnson", "Jole", "Jomuel", "Jon", "Jonah", "Jonatan", "Jonathan", "Jonathon", "Jonny", "Jonothan", "Jon-Paul", "Jonson", "Joojo", "Jordan", "Jordi", "Jordon", "Jordy", "Jordyn", "Jorge", "Joris", "Jorryn", "Josan", "Josef", "Joseph", "Josese", "Josh", "Joshiah", "Joshua", "Jude", "Jules",
                  "Julian", "Julien", "Jun", "Junior", "Jura", "Justan", "Justin", "Justinas", "Kaan", "Kabeer", "Kabir", "Kacey", "Kacper", "Kade", "Kaden", "Kaison", "Kale", "Kaleb", "Kaleem", "Kane",
                  "Karam", "Karamvir", "Karandeep", "Kareem", "Karim", "Karimas", "Karl", "Karol", "Karson", "Karsyn", "Karthikeya", "Kasey", "Kasper", "Kasra", "Kavin", "Kayam", "Kaydan", "Kayden", "Kaydin", "Kaydyn", "Kayleb", "Kaylem", "Kaylum", "Kayne", "Kaywan", "Kealan", "Kean", "Keane", "Kearney", "Keaton", "Keavan", "Keayn", "Kedrick", "Keegan", "Keelan", "Keelin", "Keeman", "Keenan", "Keenan-Lee", "Keeton", "Kehinde", "Keigan", "Keilan", "Keir", "Keiran", "Kelan", "Kellan", "Kellen", "Kelso", "Kelum", "Kelvan", "Kelvin", "Ken", "Kenan", "Kendall",
                  "Kenneth", "Kensey", "Kenton", "Kenyon", "Kenzeigh", "Kenzi", "Kenzie", "Kenzo", "Kenzy", "Keo", "Ker", "Kern", "Kerr", "Kevan", "Kevin", "Kevyn", "Kian", "Kienan", "Kier", "Kieran", "Kieran-Scott", "Kieren", "Kierin", "Kieron", "Kile", "Killian", "Kimi", "Kingston", "Kinneil", "Kinnon", "Kinsey", "Kiran", "Kirk", "Kobe", "Kodi", "Kodie", "Kody","Kyle", "Kylian",
                  "Laughlan", "Lauren", "Laurence", "Laurie", "Lawlyn", "Lawrence", "Lawrie", "Lawson", "Layne", "Layton", "Lee", "Leigh", "Leigham", "Leighton", "Leilan", "Leiten",
                  "Lennon", "Lennox", "Lenny", "Leno", "Lenon", "Leo", "Leon", "Leonard", "Leroy", "Leven", "Levi", "Levy", "Lewis", "Lex", "Leydon", "Leyland", "Leylann", "Leyton", "Liam", "Lincoln", "Lincoln-John", "Lincon", "Linden", "Linton", "Lionel", "Lloyd", "Lloyde", "Loche", "Lochlan", "Lochlann", "Logan", "Loudon", "Loui", "Louie", "Louis", "Loukas", "Lovell", "Luc", "Luca", "Lucais", "Lucas", "Lucca", "Lucian", "Luciano", "Luis", "Luka", "Lukas", "Luke", "Mac", "Macallum", "Macaulay", "Mack", "Mackenzie", "Maddison", "Maddox", "Madison", "Magnus", "Malachy", "Malcolm", "Marcel",
                  "Markus", "Marley", "Marlin", "Marlon", "Maros", "Marshall", "Martin", "Marty", "Martyn", "Marvellous", "Marvin", "Mason", "Mason-Jay", "Mathew", "Mathias", "Mathuyan", "Matt", "Matteo", "Matthew", "Matthias", "Max", "Micah", "Michael", "Mickey", "Miguel", "Miles", "Mitch", "Mitchel", "Mitchell", "Moad", "Moayd", "Morris", "Murray", "Nader", "Nate", "Nathan", "Neil", "Nelson", "Nial", "Niall", "Nicholas", "Nick", "Nicolas",
                  "Odhran", "Odin", "Odynn", "Ogheneochuko", "Ogheneruno", "Ohran", "Oilibhear", "Oisin", "Olaf", "Ola-Oluwa", "Ole", "Olie", "Oliver", "Olivier", "Ollie", "Oran", "Orin", "Orlando", "Orley", "Orran",
                  "Orrick", "Orrin", "Orson", "Oryn", "Oscar", "Oswald", "Owen", "Owyn", "Oz", "Ozzy", "Pablo", "Pacey", "Padraig", "Paolo", "Pardeepraj", "Parkash", "Parker", "Patrick", "Patrick-John", "Paul", "Pavit", "Pawel", "Pawlo", "Pearce", "Pearse", 
                  "Pele", "Peter", "Phani", "Philip", "Pierce", "Porter", "Preston", "Quinn", "Rafael", "Ralph", "Raphael", "Ray", "Raymond", "Rayne", "Reace", "Reagan", "Reece", "Reed", "Reegan", "Reese", "Reeve", "Regan", "Regean", "Reggie", "Rehaan","Reice", "Reid", "Reigan", "Reilly", "Remy", "Riccardo", "Ricco", "Rice", "Richard", "Richey", "Richie", "Ricky", "Rico", "Ridley", "Rikki", "Riley", "Rob", "Robbi", "Robbie", "Robby", "Robert", "Robin", "Roddy", "Roderick", "Rodrigo", "Rogan", "Roger", "Ronan", "Ronin", "Ronnie", "Rory", "Roshan", "Ross", "Ruari", "Ruaridh", "Rubin",
                  "Ryden", "Ryder", "Ryese", "Ryhs", "Rylan", "Ryleigh", "Ryley", "Rylie", "Ryo", "Ryszard", "Saad", "Sabeen", "Sachkirat", "Saffi", "Salvador", "Sam", "Samual", "Samuel",
                  "Samuela", "Samy", "Sanaullah", "Sandro", "Sandy", "Sanfur", "Sanjay", "Santiago", "Santino", "Satveer", "Saul", "Saunders", "Savin", "Sayad", "Sayeed", "Sayf", "Scot", "Scott", "Scott-Alexander", "Seaan", "Seamas", "Seamus", "Sean", "Seane", "Sean-James", "Sean-Paul", "Sean-Ray", "Seb", "Sebastian", "Sebastien",
                  "Sergei", "Sergio", "Seth", "Sethu", "Seumas", "Shaarvin", "Shadow", "Shae", "Shahmir", "Shai", "Shane", "Shannon", "Sharland", "Sharoz", "Shaun", "Shaunpaul", "Shaun-Paul", "Shaun-Thomas", "Shaurya", "Shaw",
                  "Shawn", "Shea", "Simon", "Stefan", "Stephen", "Stephenjunior", "Steve", "Steven", "Steven-lee", "Stevie", "Stewart", "Stuart", "Surien", "Sweyn", "Syed", "Symon", "Tadhg", "Taegan", "Taegen",  "Tanay", "Tane", "Tanner", "Tanvir", "Tanzeel", "Taonga", "Taylor", "Teagan", "Tee", "Teejay", "Tee-jay", "Tegan", "Teighen", "Terry", "Teydren", "Theo", "Theodore", "Thomas", "Tiernan", "Timothy", "Tom", "Tomas", "Tomasz", "Tommy", "Tony",
                   "Victor", "Victory", "Vince", "Vincent", "Vincenzo", "Vinnie", "Vladimir", 
                   "Warren", "Warrick", "Wayde", "Wayne", "Will", "William", "Wilson", "Windsor", "Wojciech", "Wyatt", "Wylie", "Wynn", 
                   "Xander", "Xavier", "Yanick", "Zach", "Zachariah", "Zacharias", "Zacharie", "Zacharius", "Zachariya", "Zachary", "Zack", "Zackary", "Zane"};

        public string GenerateRandomName()
        {
            string combinedName = $"{getRandomFirstName()} {getRandomLastName()}";
            return combinedName;
        }

        public bool GenerateRandomPrivate()
        {
            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            return randomBool;
        }

        public string getRandomFirstName()
        {
            // Create a Random object  
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(_firstnames.Length);

            return _firstnames[index];
        }

        public string getRandomLastName()
        {
            // Create a Random object  
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(_lastName.Length);

            return _lastName[index];
        }

        public int GenerateRandomNumber(int min = 1, int max = 100)
        {
            Random random = new Random(); return random.Next(min, max);
        }
    }
}