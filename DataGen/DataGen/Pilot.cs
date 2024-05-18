using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen;

public static class Pilot
{
    public static void Generate()
    {
        Console.WriteLine("Generating luggages");
        const int MAX_CAP = 2000;
        File.WriteAllText("../pilot.sql", string.Empty);
        FileStream f = File.Create("../pilot.sql");
        StreamWriter sw = new(f);

        DateTime dob, empDate;
        string first, last, address;
        int empId, wage, flightHours;

        // insert into pilot (empId, firstName, lastName, wage, dob, address, empDate, flightHours) values (...);
        for (int i = 0; i < MAX_CAP; i++)
        {
            var rand = new Random(i);

            empId = rand.Next(1000, 100_000);

            dob = RandomDate(new DateTime(1965, 1, 1),
                               new DateTime(1965, 1, 1),
                               rand);

            empDate = RandomDate(new DateTime(2006, 1, 1),
                                        DateTime.Now,
                                        rand);

            first = FirstNames[rand.Next(FirstNames.Count)];
            last = LastNames[rand.Next(LastNames.Count)];
            address = ""; // todo
            wage = rand.Next(16000, 30000);
            flightHours = rand.Next(100, 2000);

            sw.WriteLine($"insert into pilot (empId, firstName, lastName, wage, dob, address, empDate, flightHours) values ({empId},'{first}','{last}',{wage},'{address}',to_date('{empDate}', 'YYYY/MM/DD'),{flightHours});");
        }

        sw.Flush();
        sw.Close();
    }

    private static DateTime RandomDate(DateTime start, DateTime end, Random rand)
    {
        int range = (end - start).Days;
        return start.AddDays(rand.Next(range));
    }

    public static List<string> FirstNames = [
        "Daniel", "William", "James", "Alexander", "Michael", "John", "David", "Ethan", "Joseph",
        "Matthew", "Nicholas", "Andrew", "Anthony", "Christopher", "Ryan", "Joshua", "Tyler", "Brandon",
        "Dylan", "Samuel", "Nathan", "Christian", "Logan", "Justin", "Benjamin", "Jonathan", "Caleb",
        "Aaron", "Jackson", "Kevin", "Jose", "Robert", "Zachary", "Austin", "Elijah", "Cameron", "Thomas",
        "Jason", "Luke", "Adam", "Connor", "Isaac", "Jordan", "Evan", "Brian", "Eliyahu", "Alex",
        "Eric", "Gabriel", "Isaiah", "Jake", "Cody", "Seth", "Mason", "Adrian", "Juan", "Gavin",
        "Cole", "Hunter", "Bryan", "Carlos", "Ian", "Kyle", "Sean", "Liam", "Jaden", "Owen", "Diego",
        "Timothy", "Dominic", "Jeremiah", "Jesse", "Henry", "Patrick", "Chase", "Eli", "Wyatt", "Colton",
        "Lucas", "Eduardo", "Antonio", "Julian", "Carter", "Max", "Avery", "Parker", "Tristan", "Trevor",
        "Colin", "Brendan", "Alexis", "Jeffrey", "Blake", "Kaden", "Miguel", "Hector", "Joel", "Victor",
        "Devin", "Gage", "Garrett", "Peter", "Brayden", "Ivan", "Riley", "Kaleb", "Dominick", "Santiago",
        "Derek", "Jared", "Giovanni", "Nicolas", "Eli", "Dustin", "Fernando", "Tanner", "Vincent", "Cesar",
        "Maxwell", "Edgar", "Travis", "Shane", "George", "Preston", "Levi", "Oscar", "Mario", "Felix", "Colby",
        "Angel", "Manuel", "Sergio", "Edwin", "Emmanuel", "Ricardo", "Alec", "Jonah", "Martin", "Andre", "Paul",
        "Chance", "Micah", "Cooper", "Malachi", "Simon", "Dawson", "Marco", "Kenneth", "Troy", "Grant", "Sawyer",
        "Zane", "Dante", "Brady", "August", "Bryson", "Amir", "Hayden", "Kai", "Landon", "Raul", "Brody",
        "Damian", "Lane", "Israel", "Dominique", "Cristian", "Leonardo", "Philip", "Zion", "Dillon", "Miles",
        "Ronald", "Joaquin", "Raymond", "Armando", "Andy", "Jay", "Enrique", "Philip", "Douglas", "Noel",
        "Eden", "Jamal", "Rafael", "Randy", "Kameron", "Keith", "Darius", "Frank", "Chris", "Braden",
        "Graham", "Russell", "Skyler", "Finn", "Marshall", "Emanuel", "Nehemiah", "Lawrence", "Orlando",
        "Emma", "Olivia", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Harper", "Evelyn",
        "Abigail", "Emily", "Elizabeth", "Mila", "Ella", "Avery", "Sofia", "Camila", "Aria", "Scarlett",
        "Victoria", "Madison", "Luna", "Grace", "Chloe", "Penelope", "Layla", "Riley", "Zoey", "Nora"
    ];

    public static List<string> LastNames = [
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez",
        "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore",
        "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez",
        "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen",
        "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell",
        "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cohen", "Edwards",
        "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez",
        "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim",
        "Cox", "Ward", "Richardson", "Watson", "Brooks", "Levy", "Wood", "James", "Bennett", "Gray",
        "Mendoza", "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long",
        "Ross", "Foster", "Jimenez", "Powell", "Jenkins", "Perry", "Russell", "Sullivan", "Bell",
        "Coleman", "Butler", "Henderson", "Barnes", "Gonzales", "Fisher", "Vasquez", "Simmons", "Romero",
        "Jordan", "Patterson", "Alexander", "Hamilton", "Graham", "Reynolds", "Griffin", "Wallace",
        "Moreno", "West", "Cole", "Hayes", "Bryant", "Herrera", "Gibson", "Ellis", "Tran", "Medina",
        "Aguilar", "Stevens", "Murray", "Ford", "Castro", "Marshall", "Owens", "Harrison", "Fernandez",
        "Mcdonald", "Woods", "Washington", "Kennedy", "Wells", "Vargas", "Henry", "Freeman", "Luna",
        "Williamson", "Dean", "Carpenter", "Webb", "Sutton", "Gregory", "Reyes", "Garza", "Harvey",
        "Romero", "Burgess", "Ruiz", "Diaz", "Fields", "Weaver", "Ryan", "Morgan", "Crawford", "Ortega",
        "Schmidt", "Ruiz", "Gutierrez", "Sims", "Nichols", "Figueroa", "Gardner", "Reyes", "Maldonado",
        "Pierce", "Berry", "Franklin", "Roy", "Leon", "Boyd", "Richards", "Guzman", "Clarke", "Wagner",
        "William", "Montgomery", "Harper", "Jensen", "Mendoza", "Patton", "Huang"
    ];

}
