namespace DataGen;

public partial class Program()
{
    public static void Main(string[] argv)
    {
        Luggage.Generate();
        Carousel.Generate();
        Pilot.Generate();
    }
}
