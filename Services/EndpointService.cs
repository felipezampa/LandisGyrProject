using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LandisGyrProject.Model;

namespace LandisGyrProject.Services
{
    public class EndpointService : IService<EndpointModel>
    {
        private List<EndpointModel> endpoints = new List<EndpointModel>();
        public string Create(EndpointModel endpoint)
        {
            try
            {
                Console.Write("Endpoint Serial Number: ");
                endpoint.serialNumber = Console.ReadLine();

                // Check for duplicate serial number
                if (endpoints.Any(e => e.serialNumber == endpoint.serialNumber))
                {
                    Console.WriteLine("Error: An endpoint with this serial number already exists.");
                    return null;
                }

                Console.Write("Meter Firmware Version: ");
                endpoint.meterFirmwareVersion = Console.ReadLine();

                // Input validation for integer fields
                endpoint.meterNumber = GetValidatedIntInput("Meter Number (Must be a number): ");
                endpoint.meterModelId = GetValidatedIntInput("Meter Model Id (Must be a number): ");
                endpoint.switchState = GetValidatedIntInput("Switch State (Must be a number): ");

                endpoints.Add(endpoint);
                Console.WriteLine("Endpoint created successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured, please try again.");
            }
                
            return endpoint.serialNumber;
        }

        public IEnumerable<EndpointModel> ListAll()
        {
            if (!endpoints.Any())
            {
                return null;
            }
            else
            {
                return endpoints;
            }
        }
        public void Update(string id, EndpointModel endpoint)
        {

        }
        public string Delete(string id)
        {
            // Find the endpoint using the serial number
            EndpointModel endpointToDelete = endpoints.FirstOrDefault(e => e.serialNumber == id);

            if (endpointToDelete == null)
            {
                Console.WriteLine("Error: No endpoint found with the given serial number.");
                return null;
            }

            endpoints.Remove(endpointToDelete);
            Console.WriteLine("Endpoint deleted successfully.");


            return endpointToDelete.serialNumber;
        }

        public EndpointModel Find(Func<EndpointModel, bool> predicate)
        {
            return endpoints.FirstOrDefault(predicate);
        }

        private int GetValidatedIntInput(string helpText)
        {
            int value;
            while (true)
            {
                Console.Write(helpText);
                string input = Console.ReadLine();

                // Try to parse input to int, if successful, break out of loop
                if (int.TryParse(input, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            return value;
        }
    }
}
