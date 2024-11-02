using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LandisGyrProject.Model;
using LandisGyrProject.Model.Enum;
using LandisGyrProject.View;

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
                endpoint.SerialNumber = Console.ReadLine();

                // Check for duplicate serial number
                if (endpoints.Any(e => e.SerialNumber == endpoint.SerialNumber))
                {
                    Console.WriteLine("Error: An endpoint with this serial number already exists.");
                    return null;
                }

                Console.Write("Meter Firmware Version: ");
                endpoint.MeterFirmwareVersion = Console.ReadLine();

                // Input validation for integer fields
                endpoint.MeterNumber = GetValidatedIntInput("Meter Number (Must be a number): ");
                endpoint.MeterModelId = GetValidatedMeterModelId();
                endpoint.SwitchState = GetValidatedSwitchState();

                endpoints.Add(endpoint);
                Console.WriteLine("Endpoint created successfully.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured, please try again.");
            }
                
            return endpoint.SerialNumber;
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

        public string Update(string serialNumber, EndpointModel endpoint)
        {
            Console.WriteLine("Current Switch State: " + endpoint.SwitchState);
            endpoint.SwitchState = GetValidatedSwitchState();

            return $"Endpoint with Serial Number: {serialNumber} was successfully updated.";
        }


        public string Delete(string serialNumber)
        {
            // Find the endpoint using the serial number
            EndpointModel endpointToDelete = endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);

            if (endpointToDelete == null)
            {
                Console.WriteLine("Error: No endpoint found with the given serial number.");
                return null;
            }

            endpoints.Remove(endpointToDelete);
            Console.WriteLine("Endpoint deleted successfully.");


            return endpointToDelete.SerialNumber;
        }

        public EndpointModel Find(string serialNumber)
        {
            return endpoints.FirstOrDefault(e => e.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        }

        public int GetValidatedIntInput(string helpText)
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

        private MeterModelId GetValidatedMeterModelId()
        {
            while (true)
            {
                UiViews.ShowEnumOptionsView<MeterModelId>("Meter Model Id");

                if (int.TryParse(Console.ReadLine(), out int result) && Enum.IsDefined(typeof(MeterModelId), result))
                {
                    return (MeterModelId)result;
                }
                Console.WriteLine("Invalid input. Please select a valid Meter Model Id.");
            }
        }

        private SwitchState GetValidatedSwitchState()
        {
            while (true)
            {
                UiViews.ShowEnumOptionsView<SwitchState>("Switch State");

                if (int.TryParse(Console.ReadLine(), out int result) && Enum.IsDefined(typeof(SwitchState), result))
                {
                    return (SwitchState)result;
                }
                Console.WriteLine("Invalid input. Please select a valid Switch State.");
            }
        }
    }
}
