using System;

namespace Lab19_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Nikita", new DateTime(1998, 9, 23), "JH67423");
            Flight flight = new Flight(6, "Минск", "Москва", new DateTime(2023, 2, 3, 13, 37, 00), "Boeing 737", 160, 393.21);

            Console.WriteLine("---- Adapter ----");
            client.Travel(flight);

            Bus bus = new Bus();

            ITravel busToAirport = new Adapter(bus);
            client.Travel(busToAirport);

            Console.WriteLine("\n---- Decorator ----");
            flight = new FlightWithAirport("Minsk", "Moskow Airport", flight);
            Console.WriteLine(flight.ToString());

            //три паттерна поведения.
            Console.WriteLine("\n---- State ----");
            client.MakeOrder(flight);

            Console.WriteLine("\n---- Command ----");
            Flight flight1 = new Flight(4, "Барселона", "Берлин", new DateTime(2023, 1, 15, 1, 01, 00), "Boeing 737", 214, 230);
            Admin admin = new Admin();
            admin.SetCommand(new FlightOnCommand(flight1));
            admin.AddNewFlight();
            admin.CancelFlight();

            Console.WriteLine("\n---- Strategy ----");
            Bus bus1 = new Bus("Mercedes", 1243, new PetrolMove());
            bus1.Move();
            bus1.Movable = new ElectricMove();
            bus1.Move();
        }
    }
}
