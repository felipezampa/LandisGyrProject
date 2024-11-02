using System;
using System.Collections.Generic;
using System.Linq;
using LandisGyrProject.Exceptions;
using LandisGyrProject.Model;
using LandisGyrProject.Model.Enum;
using LandisGyrProject.View;

namespace LandisGyrProject.Services
{
    public class EndpointService : IService<EndpointModel>
    {
        private List<EndpointModel> endpoints = new List<EndpointModel>();

        /// <summary>
        /// Creates a new endpoint with the provided details.
        /// </summary>
        /// <param name="endpoint">The endpoint model to be created.</param>
        /// <returns>The serial number of the created endpoint.</returns>
        public string Create(EndpointModel endpoint)
        {
            Console.Write("Endpoint Serial Number: ");
            endpoint.SerialNumber = Console.ReadLine();

            // Check for duplicate serial number
            if (endpoints.Any(e => e.SerialNumber == endpoint.SerialNumber))
            {
                throw new DuplicateSerialNumberException($"An endpoint with the serial number '{endpoint.SerialNumber}' already exists.");
            }

            Console.Write("Meter Firmware Version: ");
            endpoint.MeterFirmwareVersion = Console.ReadLine();

            // Input validation for integer fields
            endpoint.MeterNumber = GetValidatedIntInput("Meter Number (Must be a number): ");
            endpoint.MeterModelId = GetValidatedMeterModelId();
            endpoint.SwitchState = GetValidatedSwitchState();

            endpoints.Add(endpoint);
                
            return endpoint.SerialNumber;
        }

        /// <summary>
        /// Retrieves all endpoints from the storage.
        /// </summary>
        /// <returns>An enumerable collection of endpoint models or null if no endpoints are found.</returns>
        public IEnumerable<EndpointModel> ListAll()
        {
            return endpoints.Any() ? endpoints : null;
        }

        /// <summary>
        /// Updates the switch state of the specified endpoint.
        /// </summary>
        /// <param name="serialNumber">The serial number of the endpoint to update.</param>
        /// <param name="endpoint">The endpoint to be updated.</param>
        /// <returns>The serial number of the updated endpoint.</returns>
        public string Update(string serialNumber, EndpointModel endpoint)
        {
            Console.WriteLine("Current Switch State: " + endpoint.SwitchState);
            endpoint.SwitchState = GetValidatedSwitchState();

            return serialNumber;
        }

        /// <summary>
        /// Deletes the specified endpoint by its serial number.
        /// </summary>
        /// <param name="serialNumber">The serial number of the endpoint to delete.</param>
        /// <returns>The serial number of the deleted endpoint.</returns>
        public string Delete(string serialNumber)
        {
            // Find the endpoint using the serial number
            EndpointModel endpointToDelete = endpoints.FirstOrDefault(e => e.SerialNumber == serialNumber);

            // If the endpoint does not exist, throw an exception
            if (endpointToDelete == null)
                throw new EndpointNotFoundException($"No endpoint found with the given serial number: {serialNumber}");

            endpoints.Remove(endpointToDelete);

            return endpointToDelete.SerialNumber;
        }

        /// <summary>
        /// Finds and returns the endpoint with the specified serial number.
        /// </summary>
        /// <param name="serialNumber">The serial number of the endpoint to find.</param>
        /// <returns>The found EndpointModel or null if nothing is found.</returns>
        public EndpointModel Find(string serialNumber)
        {
            return endpoints.FirstOrDefault(e => e.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Validate that the input is an integer.
        /// </summary>
        /// <param name="helpText">The message to display to the user when asking for the input.</param>
        /// <returns>The integer value after validation.</returns>
        public int GetValidatedIntInput(string helpText)
        {
            int value;
            while (true)
            {
                Console.Write(helpText);
                string input = Console.ReadLine();

                // Try to parse input to int, if successful, break out of loop
                if (int.TryParse(input, out value))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            return value;
        }

        /// <summary>
        ///  Validate that the input is a correct MeterModelId based on the Enum.
        /// </summary>
        private MeterModelId GetValidatedMeterModelId()
        {
            while (true)
            {
                UiViews.ShowEnumOptionsView<MeterModelId>("Meter Model Id");

                if (int.TryParse(Console.ReadLine(), out int result) && Enum.IsDefined(typeof(MeterModelId), result))
                    return (MeterModelId)result;

                Console.WriteLine("Invalid input. Please select a valid Meter Model Id.");
            }
        }

        /// <summary>
        ///  Validate that the input is a correct SwitchState based on the Enum.
        /// </summary>
        private SwitchState GetValidatedSwitchState()
        {
            while (true)
            {
                UiViews.ShowEnumOptionsView<SwitchState>("Switch State");

                if (int.TryParse(Console.ReadLine(), out int result) && Enum.IsDefined(typeof(SwitchState), result))
                    return (SwitchState)result;
                Console.WriteLine("Invalid input. Please select a valid Switch State.");
            }
        }
    }
}
