using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandisGyrProject.Exceptions;
using LandisGyrProject.Model;
using LandisGyrProject.Services;
using LandisGyrProject.View;

namespace LandisGyrProject.Controller
{
    public class EndpointController : IController
    {
        private EndpointService service = new EndpointService();
        public EndpointController() { }

        /// <summary>
        ///     Create a new endpoint and then informs if the operation went well
        /// </summary>
        public void Create()
        {
            Console.WriteLine("---> Create a new endpoint");
            try
            {
                EndpointModel endpoint = new EndpointModel();
                string response = service.Create(endpoint);

                if (response != null)
                    UiViews.DataManipulationResponseView(response, "created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // refazer essas exceptions se der tempo
            }
        }

        /// <summary>
        ///     Get all of the endpoints and then call the action to print on screen every object
        /// </summary>
        public void ListAll()
        {
            Console.WriteLine("---> List of all endpoints");
            try
            {
                IEnumerable<EndpointModel> endpoints = service.ListAll();
                if (endpoints == null || !endpoints.Any())
                {
                    Console.WriteLine("No endpoints found.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("All endpoints:\n");
                    foreach (EndpointModel endpoint in endpoints)
                    {
                        UiViews.PrintEndpointView(endpoint);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // refazer essas exceptions se der tempo
            }
        }

        public void Update()
        {
            Console.WriteLine("---> Update an endpoint");

            try
            {
                Console.Write("Enter the Endpoint Serial Number to update: ");
                string serialNumber = Console.ReadLine();

                // Find the endpoint with the given serial number
                EndpointModel endpoint = service.Find(serialNumber);

                if (endpoint == null)
                {
                    Console.WriteLine($"No endpoint with the Serial Number: \"{serialNumber}\" was found to update.");
                    return;
                }

                Console.WriteLine("Current Endpoint Details:");
                UiViews.PrintEndpointView(endpoint);

                string response = service.Update(serialNumber, endpoint);

                if (response != null)
                    UiViews.DataManipulationResponseView(response, "updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // refazer essas exceptions se der tempo
            }
        }

        /// <summary>
        ///     Delete an endpoint, based on the requirement it should check if exists, then ask for confirmation and finally delete the endpoint
        /// </summary>
        public void Delete()
        {
            Console.WriteLine("---> Delete an endpoint");

            try
            {
                Console.Write("Enter the Endpoint Serial Number to delete: ");
                string serialNumber = Console.ReadLine();

                // Search if the endpoint exists
                EndpointModel endpoint = service.Find(serialNumber);

                if (endpoint == null)
                {
                    Console.WriteLine($"No endpoint with the Serial Number: \"{serialNumber}\" was found to delete.");
                    return;
                }

                // Ask for confirmation before deleting
                if (AskForConfirmation())
                {
                    string response = service.Delete(serialNumber);

                    if (response != null)
                        UiViews.DataManipulationResponseView(response, "deleted");
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // refazer essas exceptions se der tempo
            }
        }

        /// <summary>
        ///     Search for a specific endpoint
        /// </summary>
        public void Find()
        {
            try
            {
                Console.Write("Enter the Endpoint Serial Number: ");
                string serialNumber = Console.ReadLine();
                EndpointModel endpoint = service.Find(serialNumber);
                if (endpoint == null)
                {
                    Console.WriteLine($"No endpoint with the Serial Number: {serialNumber} was found.");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Endpoint founded:\n");
                    UiViews.PrintEndpointView(endpoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // refazer essas exceptions se der tempo
            }
        }

        /// <summary>
        ///     Ask for confirmation on a given action
        /// </summary>
        public bool AskForConfirmation()
        {
            // Since a lot of actions are requiring confirmation I decided to create this method so it's easy to check confirmation when needed
            UiViews.AskForConfirmationView();

            int optionSelected = service.GetValidatedIntInput("Your choice:  ");

            return optionSelected == 1 ?  true : false;
        }

        /// <summary>
        ///     Shows the options and retrieve the selected one
        /// </summary>
        public int OptionsMenu()
        {
            UiViews.OptionsMenuView();

            int optionSelected = service.GetValidatedIntInput("Your choice:  ");

            return optionSelected;
        }
    }
}
