namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var m = new RaceMotorcycle(10,20);

            System.Console.WriteLine(m.FuelConsumption);
        }
    }
}
