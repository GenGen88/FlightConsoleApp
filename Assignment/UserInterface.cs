using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Testing
{
    class UserInterface
    {
        // fields?
        static bool running = true;
        public static bool loggedIn = true;
        

        // methods
        public static void startingScreen()
        {
            while (running == true)
            {
                Console.WriteLine("Select one of the following\n1) Register as new Employee\n2) Login as Existing Employee \n3) Exit");
                int userInput;
                string input = Console.ReadLine();
                if (int.TryParse(input, out userInput))
                {
                    switch (userInput)
                    {
                        case 1: // Register as new employee
                            Employee registerEmployee = new Employee();
                            registerEmployee.registerEmployee();
                            break;
                        case 2: // login as existing employee
                            Employee employeeLogin = new Employee();
                            employeeLogin.login();
                            break;
                        case 3: // exit
                            exit();
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;

                    }
                }
                else // exception handling
                {
                    Console.WriteLine("invalid input");
                }
            }
            
        }

        

        public static void exit()
        {
            running = false;
        }

        public static SecureString maskInputString()
        {
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length>0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            {
                return pass;
            }

        }

        
        
        public static void EmployeeMenu()
        {
            Console.WriteLine($"\nPlease select one of the following: \n1) Register a customer\n2) Register a new light aircraft \n3) Register a new helicopter \n4) View existing flying services \n5) View existing times \n6) Add a customer to a flying service \n7) View flight passengers \n8) Logout");
            int userResponse; 
            string convert = Console.ReadLine();
            if (int.TryParse(convert, out userResponse))
            {
                switch (userResponse)
                {
                    case 1: // register a new customer
                        Employee customer = new Employee();
                        customer.registerCustomer();
                        break;
                    case 2: // register a new light aircraft
                        LightAircraft lightAircraft = new LightAircraft();
                        lightAircraft.newFlight();
                        break;
                    case 3: // register a new helicopter
                        Helicopter helicopter = new Helicopter();
                        helicopter.newFlight();
                        break;
                    case 4: // view existing flying services
                        Employee flights = new Employee();
                        flights.viewExistingFlyingServices();
                        break;
                    case 5: // view existing times (times for each flight)
                        Employee flightTimes = new Employee();
                        flightTimes.viewExisitngFlyingTimes();
                        break;
                    case 6: // add customer to flight
                        Employee addCustomer = new Employee();
                        addCustomer.addCustomerToFlight();
                        break;
                    case 7:// view flight passengers
                        Employee viewFlights = new Employee();
                        viewFlights.viewPassengers();
                        break;
                    case 8:
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
}
