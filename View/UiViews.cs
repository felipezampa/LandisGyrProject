using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandisGyrProject.Exceptions;
using LandisGyrProject.Model;
using LandisGyrProject.Model.Enum;

namespace LandisGyrProject.View
{
    public class UiViews
    {
        /// <summary>
        /// Displays a welcome message for the application.
        /// </summary>
        public static void WelcomeMenuView()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("=======          Landis+Gyr Project         =======");
            Console.WriteLine("=======               Welcome               =======");
            Console.WriteLine("===================================================");
        }

        /// <summary>
        /// Displays the options menu, presenting the user with choices.
        /// </summary>
        public static void OptionsMenuView()
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("Choose your option and type the respective number:");
            Console.WriteLine("   1 - Insert a new endpoint");
            Console.WriteLine("   2 - Edit an existing endpoint");
            Console.WriteLine("   3 - Delete an existing endpoint");
            Console.WriteLine("   4 - List all endpoint");
            Console.WriteLine("   5 - Find a endpoint by \"Endpoint Serial Number\"");
            Console.WriteLine("   6 - Exit");
            Console.WriteLine("---------------------------------------------------");
        }

        /// <summary>
        /// Displays the details of a specific endpoint.
        /// </summary>
        /// <param name="endpoint">The Endpoint object to be displayed.</param>
        public static void PrintEndpointView(EndpointModel endpoint)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine($"Serial Number:          {endpoint.SerialNumber}");
            Console.WriteLine($"Meter Model ID:         {endpoint.MeterModelId}");
            Console.WriteLine($"Meter Number:           {endpoint.MeterNumber}");
            Console.WriteLine($"Meter Firmware Version: {endpoint.MeterFirmwareVersion}");
            Console.WriteLine($"Switch State:           {endpoint.SwitchState} ");
        }

        /// <summary>
        /// Asks the user for confirmation before proceeding with an action.
        /// </summary>
        public static void AskForConfirmationView()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("=======            Are you sure?            =======");
            Console.WriteLine("=======         1) Yes         2)No         =======");
            Console.WriteLine("===================================================");
        }
        
        /// <summary>
        /// Displays a response message indicating the result of a data manipulation operation.
        /// </summary>
        /// <param name="serialNumber">The serial number of the endpoint that was manipulated.</param>
        /// <param name="action">The action performed.</param>
        public static void DataManipulationResponseView(string serialNumber, string action)
        {
            Console.Clear();
            Console.WriteLine($"The Endpoint of Serial Number: \"{serialNumber}\" was {action} successfully");
        }

        /// <summary>
        /// Displays options for a specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum to display options for.</typeparam>
        /// <param name="value">A description of the enum options (for display purposes).</param>
        public static void ShowEnumOptionsView<TEnum>(string value) where TEnum : Enum
        {
            Console.WriteLine($"{value} options (Type the number of the option wanted)");
            foreach (var state in Enum.GetValues(typeof(TEnum)))
            {
                Console.WriteLine($"{ (int)state}: {state}");
            }
            Console.Write($"Select the {value}:");
        }
    }
}
