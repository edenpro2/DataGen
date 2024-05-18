namespace DataGen;

public static class Luggage
{
    public static void Generate()
    {
        Console.WriteLine("Generating luggages");
        const int MAX_CAP = 10000;
        File.WriteAllText("../luggage.sql", string.Empty);
        FileStream f = File.Create("../luggage.sql");
        StreamWriter sw = new(f);

        int tag;
        double weight;
        string type;
        string[] types = ["checked", "carryOn", "personal", "special", "fragile", "equipment"];
        int aircraftID;
        int carouselID;

        

        // insert into luggage (tag, weight, type) values (1, 31.74, 'personal');
        for (int i = 0; i < MAX_CAP; i++)
        {
            var rand = new Random(i);
            tag = rand.Next(100_000, 1_000_000);
            weight = (rand.NextDouble() * (32.0 - 1)) + 1;
            type = types[rand.Next(0, types.Length)];

            if (rand.Next(0, 2) == 1)
            {
                // check for used id
                aircraftID = rand.Next(10_000, 1_000_000);
                
                sw.WriteLine($"insert into luggage (tag, weight, type, aircraftId, carousel) values ({tag},{weight},'{type}','',{aircraftID});");
            }
            else
            {
                carouselID = rand.Next(1, 30);
                sw.WriteLine($"insert into luggage (tag, weight, type, aircraftId, carousel) values ({tag},{weight},'{type}',{carouselID},'');");
            }

        }

        sw.Flush();
        sw.Close();
    }
}
