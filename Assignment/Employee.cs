using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Employee
    {
        // fields
        private string name;
        private string email;
        private string password;

        // properties
        public string Name
        {
            get { return name; }
            set { value = name; }
        }

        public string Email
        {
            get { return email; }
            set { value = email; }
        }

        public string Password
        {
            get { return password; }
            set { value = password; }
        }


        // constructor
        public Employee(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public Employee()
        {
            name = string.Empty;
            email = string.Empty;

        }

        // methods
        public void registerEmployee()
        {
            Console.WriteLine("Full name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            //UserInterface.maskInputString(); // prevents text copying to file :*(
            string password = Console.ReadLine();
            Employee var = new Employee(name, email, password);
            Console.WriteLine($"{name} registered successfully");
            using (FileStream outputFile = new FileStream ("employee.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(outputFile);
                outputFile.Close();
            }
            using StreamWriter sw = File.AppendText("employee.txt");
            sw.WriteLine($"{name} {email} {password}");
            sw.Flush();
            sw.Close();
        }

        public void login()
        {
            Console.WriteLine("Email: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Password: ");
            UserInterface.maskInputString();
            string userPassword = Console.ReadLine();
            using (StreamReader sr = new StreamReader("employee.txt"))
            {
                
                string line;
                line = sr.ReadToEnd();

                if (line.Contains(userEmail) && line.Contains(userPassword))
                {
                    string[] names = line.Split(" ");
                    Console.WriteLine($"welcome employee"); 
                    UserInterface.loggedIn = true;
                    while (UserInterface.loggedIn == true)
                    {
                        UserInterface.EmployeeMenu();
                    }

                }

                else
                {
                    Console.WriteLine("Invalid email or password, please try again");
                }

            }
            
            
        }

        public void registerCustomer()
        {
            Console.WriteLine($"Full name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine($"Email: ");
            string customerEmail = Console.ReadLine();
            Console.WriteLine($"Address: ");
            string customerAddress = Console.ReadLine();
            Console.WriteLine($"Mobile: ");
            string customerMobile = Console.ReadLine();
            Customer var = new Customer(customerName, customerEmail, customerAddress, customerMobile);
            Console.WriteLine($"{customerName} registered succesfully");
            using (FileStream customers = new FileStream("customers.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(customers);
                customers.Close();
            }
            using StreamWriter customerWriter = File.AppendText("customers.txt");
            customerWriter.WriteLine($"{customerName}");
        }

        

        

        public void viewExistingFlyingServices()
        {
            if (File.Exists("flights.txt"))
            {
                using (StreamReader readFlights = new StreamReader("flights.txt"))
                {
                    string flights = readFlights.ReadToEnd();
                    Console.WriteLine(flights);
                }

            }
            else
            {
                Console.WriteLine("error no flights exist yet");
            }
        }

        public void viewExisitngFlyingTimes()
        {
            if (File.Exists("flightTimes.txt"))
            {
                using (StreamReader readFlightTimes = new StreamReader("flightTimes.txt"))
                {
                    string flightTimes = readFlightTimes.ReadToEnd();
                    Console.WriteLine(flightTimes);
                }
            }
            else
            {
                Console.WriteLine("error no flights exist yet");
            }
        }

        public void addCustomerToFlight()
        {
            if (File.Exists("customers.txt") && File.Exists("flights.txt"))
            {
                Console.WriteLine("Choose a customer to add to flight: ");
                string customersUnsplit;
                using (StreamReader custmers = new StreamReader("customers.txt"))
                {
                    customersUnsplit = custmers.ReadToEnd();

                }

                string[] customersArray = customersUnsplit.Split("\n");
                for (int i = 0; i < customersArray.Length - 1; i++)
                {
                    int numbers = i + 1;
                    Console.WriteLine($"{numbers} {customersArray[i]}");

                }

                string selectedCustomer = Console.ReadLine();
                int CustomerInt;
                if (int.TryParse(selectedCustomer, out CustomerInt) && CustomerInt <= customersArray.Length - 1)
                {

                    string customerChoice = customersArray[CustomerInt - 1];
                    //Console.WriteLine(customerChoice);
                    Console.WriteLine("Choose a flight for the customer: ");
                    string customerFlight;
                    using (StreamReader customerSR = new StreamReader("flights.txt"))
                    {
                        customerFlight = customerSR.ReadToEnd();

                        string[] flightsArray = customerFlight.Split("\n");
                        for (int i = 0; i < flightsArray.Length-1; i++)
                        {
                            int numbers = i + 1;
                            Console.WriteLine($"{numbers} {flightsArray[i]}");
                        }

                        string selectedFlight = Console.ReadLine();
                        int FlightInt;
                        if (int.TryParse(selectedFlight, out FlightInt) && FlightInt <= flightsArray.Length-1)
                        {
                            // create passengers.txt and add stuff to that
                            using (FileStream passengers = new FileStream("passengers.txt", FileMode.OpenOrCreate))
                            {
                                StreamWriter writer = new StreamWriter(passengers);
                                passengers.Close();
                            }
                            using StreamWriter passengerWriter = File.AppendText("passengers.txt");
                            passengerWriter.WriteLine($"\n{customerChoice}\nis on \n{flightsArray[FlightInt - 1]}");
                            Console.WriteLine($"\n{ customerChoice}\n added to \n{flightsArray[FlightInt - 1]}");
                            // {customers[CustomerInt-1]} selected customer
                            // {flightsArray[FlightInt-1]} selected flight
                        }
                        else
                        {
                            Console.WriteLine("invalid input");
                        }
                    }
                }
                else // exception handling
                {
                    Console.WriteLine("invalid input");
                }
                

            }
            else // exception handling
            {
                Console.WriteLine("error no customers or flights exist yet");
            }
            

        }

        public void viewPassengers()
        {
            if (File.Exists("Passengers.txt"))
            {
                using (StreamReader readPassengers = new StreamReader("Passengers.txt"))
                {
                    string passengers = readPassengers.ReadToEnd();
                    Console.WriteLine(passengers);
                }
            }
            else
            {
                Console.WriteLine("error no flights exist yet");
            }
        }


    }
}
