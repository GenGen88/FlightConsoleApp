using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Helicopter : LightAircraft
    {

        // inheritance constructor
        public Helicopter(string depaturePlace, string arrivalPlace, DateTime depatureTime, double distance) : base(depaturePlace, arrivalPlace, depatureTime, distance)
        {

        }

        public Helicopter()
        {

        }

        public override void newFlight()
        {
            Console.WriteLine("Depature Place: ");
            string depature = Console.ReadLine();
            Console.WriteLine("Arrival Place: ");
            string arrival = Console.ReadLine();
            Console.WriteLine("Depature Time: ");
            string time = Console.ReadLine();
            var timedate = new DateTime(0, 0);
            if (DateTime.TryParse(time, out timedate))
            {

            }
            else // exception handling
            {
                Console.WriteLine("invalid input");
            }
            Console.WriteLine("Distance: ");
            string distanceString = Console.ReadLine();
            double distanceDouble;
            if (double.TryParse(distanceString, out distanceDouble))
            {

            }
            else // exception handling
            {
                Console.WriteLine("invalid input");
            }

            double flightTime = Math.Round(distanceDouble / 120, 2);
            double flightCost = Math.Round(flightTime * 600, 2);

            Helicopter var = new Helicopter(depature, arrival, timedate, distanceDouble);
            Console.WriteLine($"Helicopter from {depature} to {arrival} added");

            // adds helicopter flights to flights.txt
            using (FileStream helicopters = new FileStream("flights.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(helicopters);
                helicopters.Close();
            }
            using StreamWriter helicopterWriter = File.AppendText("flights.txt");
            helicopterWriter.WriteLine($"Helicopter {depature} {arrival} {distanceDouble}km");

            // adds flight times and cost to file flighttimes.txt
            using (FileStream helicopterTimes = new FileStream("flightTimes.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(helicopterTimes);
                helicopterTimes.Close();
            }
            using StreamWriter HelicopterFlights = File.AppendText("flightTimes.txt");
            HelicopterFlights.WriteLine($"Helicopter {depature} {arrival} {timedate} {flightTime}hrs ${flightCost}");

        }
    }
}
