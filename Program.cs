using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//^--- Visual Studio Imports---•

//•---- Import SqlClient    ---v
using System.Data.SqlClient;


namespace SSMS_DB_Application
{
    public class Program
    {

        // Global Variables
        public static bool keepGoing = true;

        // Create new SqlConnection Object
        public static SqlConnection sql = new SqlConnection("Data Source=BT228-2\\SQLExpress;Initial Catalog=classroom;Integrated Security=True");

        public static void Main(string[] args)
        {
            // Variables for the Main's scope

            // Initially created by Jamin Ghata  2/8/2018 
            Console.WriteLine("Welcome to SSMS_DB_Application!\n\n");




            // Loop
            start:
                do
                {
                    // Clear the console each time the loop happens
                    Console.Clear();

                    // Display Menu
                    displayMenu();
                
                    // Retrieve Input
                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine().ToUpper();
                    Console.Clear();

                    // If the user types in spaces 
                    if(string.IsNullOrWhiteSpace(input))
                    {
                        // Inform User the Entry Cannot be blank
                        Console.WriteLine("Entry Cannot be blank.");
                        Console.ReadKey();//Forces user to type something before clearing console
                        
                        // Return user to start label
                        goto start;
                    }
                    // If the input is input other than spaces
                    else
                    {
                        mainMenu(input);
                    }




                    //Keep the program open until the user types "EXIT"
                    //promptToContinue();
                
                } while (keepGoing);



        }

        public static void mainMenu(string input)
        {
            switch(input)
            {
                // Create/Open a connection
                case "A":
                    //Catch Exception
                    try
                    {
                        //Attempt to open connection
                        Console.WriteLine("Opening the connection...");
                        sql.Open();
                        //Dictate to the user if the connection is set to open.
                        Console.WriteLine("The connection is currently set to {0}. \n-Press any key to continue to the main menu", sql.State);
                        Console.ReadKey();
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e);
                    }
                    
                    break;

                // Close the connection
                case "B":
                    Console.WriteLine("Closing the connection...");
                    sql.Close();
                    Console.WriteLine("The connection is currently set to {0}. \n-Press any key to continue to the main menu", sql.State);
                    Console.ReadKey();

                    break;

                // Check the Connection
                case "C":
                    Console.WriteLine("The current version: " + sql.ServerVersion);
                    Console.WriteLine("The current connection is {0}. \n-Press any key to continue to the main menu.", sql.State);
                    Console.ReadKey();
                    break;

                // Exit the program
                case "X":
                    Environment.Exit(0);
                    break;

                // Default for the Menu is an error message
                default:
                    Console.WriteLine("Invalid Input! \n(Press any key to return to main menu)");
                    Console.ReadKey(); Console.Clear();
                    break;
            }
        }

        //
        public static void switchKeepGoing()
        {
            keepGoing = !keepGoing;
        }

        public static void displayMenu()
        {
            Console.WriteLine("A. Create Connection \n"
                + "B. Close Connection  \n"
                + "C. Check Connection  \n"
                + "X. Exit Program      \n");
        }

        public static void promptToContinue()
        {
            Console.WriteLine("Press any key to continue (type \"x\" or \"exit\" to exit).");
            string key = Console.ReadLine();
            key = key.ToUpper();
            if (key == "EXIT" || key == "X") { keepGoing = false; }
        }


    }
}
