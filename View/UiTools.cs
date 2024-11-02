using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandisGyrProject.Exceptions;
using LandisGyrProject.Model;

namespace LandisGyrProject.View
{
    public class UiTools
    {
        public static void WelcomeMenuView()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("=======          Landis+Gyr Project         =======");
            Console.WriteLine("=======               Welcome               =======");
            Console.WriteLine("===================================================");
        }

        public static void OptionsMenuView()
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("Choose your option and type the respective number:");
            Console.WriteLine("   1 - Insert a new endpoint");
            Console.WriteLine("   2 - Edit an existing endpoint");
            Console.WriteLine("   3 - Delete an existing endpoint");
            Console.WriteLine("   4 - List all endpoint");
            Console.WriteLine("   5 - Find a endpoint by \"Endpoint\"");
            Console.WriteLine("   6 - Exit");
            Console.WriteLine("---------------------------------------------------");
            Console.Write("Your choice:  ");
        }

        public static void PrintEndpointView(EndpointModel endpoint)
        {
            Console.WriteLine($"Serial Number:          {endpoint.serialNumber}");
            Console.WriteLine($"Meter Model ID:         {endpoint.meterModelId}");
            Console.WriteLine($"Meter Number:           {endpoint.meterNumber}");
            Console.WriteLine($"Meter Firmware Version: {endpoint.meterFirmwareVersion}");
            Console.WriteLine($"Switch State:           {endpoint.switchState}");
            Console.WriteLine("===================================================");
        }

        public static void AskForConfirmationView()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("=======            Are you sure?            =======");
            Console.WriteLine("=======         1) Yes         2)No         =======");
            Console.WriteLine("===================================================");
        }

        public static void DataManipulationResponseView(string serialNumber, string action)
        {
            Console.Clear();
            Console.WriteLine($"The Endpoint of Serial Number: \"{serialNumber}\" was {action} successfully");
        }
    }
}
