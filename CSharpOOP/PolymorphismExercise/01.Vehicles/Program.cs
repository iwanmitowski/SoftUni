using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));

            var truckInput = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

            var busInput = Console.ReadLine().Split();
            Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split();

                    var command = input[0];
                    var vehicle = input[1];
                    var value = double.Parse(input[2]);

                    switch (vehicle)
                    {
                        case "Car":
                            ExecuteCommand(command, car, value);
                            break;
                        case "Truck":
                            ExecuteCommand(command, truck, value);
                            break;
                        case "Bus":
                            ExecuteCommand(command, bus, value);
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteCommand(string command, Vehicle vehicle, double value)
        {
            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value));
            }
            else if (command == "DriveEmpty")
            {
                Console.WriteLine(((Bus)vehicle).DriveEmpty(value));
            }
            else
            {
                vehicle.Refuel(value);
            }
        }
    }
}
