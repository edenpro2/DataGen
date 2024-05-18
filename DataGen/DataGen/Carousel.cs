namespace DataGen;

public static class Carousel
{
    private static Dictionary<int, Carousel.Element> elements = new();

    internal class Element(int c, int f, int s, int t, string iata)
    {
        int carouselId, flightId, size, terminal;
        string iata;
    }

    public static void Generate()
    {
        Console.WriteLine("Generating carousels");
        const int MAX_CAP = 10000;
        File.WriteAllText("../carousel.sql", string.Empty);
        FileStream f = File.Create("../carousel.sql");
        StreamWriter sw = new(f);


        int carouselId, flightId, size, terminal;
        string iata;

        // insert into carousel (carouselId, flightId, size, terminal, iata) values (...);
        for (int i = 0; i < MAX_CAP; i++)
        {
            Random rand = new(i);

            // check for used id
            carouselId = rand.Next(100, 100001);

            while (elements != null && elements.ContainsKey(carouselId))
                carouselId = rand.Next(100, 100001);

            flightId = rand.Next(1000, 10001);
            size = rand.Next(10, 101);
            terminal = rand.Next(1, 11);
            iata = IATA[rand.Next(0, IATA.Count)];

            elements[carouselId] = new Element(carouselId, flightId, size, terminal, iata);

            sw.WriteLine($"insert into carousel (carouselId, flightId, size, terminal, iata) values ({carouselId},{flightId},{size},{terminal},'{iata}');");
        }

        sw.Flush();
        sw.Close();
    }

    public static List<string> IATA = [
        "ATL", "LAX", "ORD", "DFW", "DEN", "JFK", "SFO", "SEA", "LAS", "MCO", "EWR", "MIA", "CLT", "PHX", "IAH", "MSP", "BOS", "DTW", "PHL", "LGA", "FLL", "BWI", "SAN", "MDW", "IAD", "DCA", "HNL", "TPA", "PDX", "STL", "SLC", "MCI", "MSY", "CVG", "OAK", "SMF", "RDU", "IND", "SAT", "PIT", "SNA", "CLE", "TLV","BNA", "AUS", "DAL", "MKE", "BDL", "SJC", "ABQ", "BHM", "BUF", "JAX", "RSW", "OGG", "CMH", "GRR", "TUS", "DAY", "ORF", "GSO", "GSP", "SRQ", "OKC", "ICT", "MEM", "BTV", "LIT", "CHS", "BOI", "HSV", "PBI", "SYR", "AMA", "GRB", "BZN", "FAR", "PVD", "CAK", "EUG", "MHT", "RIC", "PWM", "CID", "LBB", "FAT", "GEG", "ALB", "XNA", "CRP", "GPT", "AVL", "SDF", "ROC", "BTR", "RNO", "LAN", "ELP", "MYR", "TYS", "COS", "SAV", "EVV", "ERI", "GNV", "MFR", "BGR", "BMI", "JNU", "FNT", "AGS", "TLH", "SPI", "CHO", "JAN", "LAN", "ERI", "ROA", "SRQ", "LFT", "TOL", "MCN", "OAJ", "LEX", "SBN", "MGM", "AVL", "YVR", "YYZ", "YYC", "YUL", "YEG", "YOW", "YYZ", "YHZ", "YWG", "YXE", "YHM", "YXX", "YLW", "YQR", "YQB", "YXE", "YWG", "YOW", "YHZ", "YXE", "YQG", "YXU", "YKF", "YCD", "YQT", "YXX", "YXX", "YZV", "YXY", "YBR", "YSB", "YQT", "YCG", "YXJ", "YMM", "YXY", "YZP", "YXC", "YQG", "YQU", "YXS", "YTS", "YTH", "YRT", "YUL", "YKF", "YZV", "YQY", "YQB", "YFC", "YCD", "YKA", "YXS", "YBL", "YQG", "YSR", "YDF", "YXU", "YHM", "YXH", "YSB", "YXY", "YQR", "YLL", "YQT", "YTS", "YQY", "YWG", "YMM", "YZF", "YBR"
    ];
}
