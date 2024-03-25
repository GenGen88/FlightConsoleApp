using System;
using System.IO;

namespace Testing
{
    class LightAircraft
    {
        // fields
        private string depaturePlace;
        private string arrivalPlace;
        private DateTime depatureTime;
        private double distance;

        // properties
        public string DepaturePlace
        {
            get { return depaturePlace; }
            set { value = depaturePlace; }
        }

        public string ArrivalPlace
        {
            get { return arrivalPlace; }
            set { value = arrivalPlace; }
        }

        public DateTime DepatureTime
        {
            get { return depatureTime; }
            set { value = depatureTime; }
        }

        public double Distance
        {
            get { return distance; }
            set { value = distance; }
        }

        // constructor
        public LightAircraft(string depature, string arrival, DateTime time, double distance)
        {
            this.depaturePlace = depature;
            this.arrivalPlace = arrival;
            this.depatureTime = time;
            this.distance = distance;

        }
        public LightAircraft()
        {

        }


        public virtual void newFlight()
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

            double flightTime = Math.Round(distanceDouble / 800, 2);
            double flightCost = Math.Round(flightTime * 200, 2);

            LightAircraft var = new LightAircraft(depature, arrival, timedate, distanceDouble);
            Console.WriteLine($"Light Aircraft from {depature} to {arrival} added");

            // adds flight to file flights.txt
            using (FileStream flights = new FileStream("flights.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(flights);
                flights.Close();
            }
            using StreamWriter swDepature = File.AppendText("flights.txt");
            swDepature.WriteLine($"Light Aircraft {depature} {arrival} {distanceDouble}km");

            // adds flight times and cost to file flighttimes.txt
            using (FileStream flightTimes = new FileStream("flightTimes.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(flightTimes);
                flightTimes.Close();
            }
            using StreamWriter lightAircraftflights = File.AppendText("flightTimes.txt");
            lightAircraftflights.WriteLine($"Light Aircraft {depature} {arrival} {timedate} {flightTime}hrs ${flightCost}");


        }


    }
}