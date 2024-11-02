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
        private List<EndpointModel> endpoints = new List<EndpointModel>();
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
                    UiTools.DataManipulationResponseView(response, "created");
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
                        UiTools.PrintEndpointView(endpoint);
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
                EndpointModel endpoint = service.Find(e => e.serialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));

                if (endpoint == null)
                {
                    Console.WriteLine($"No endpoint with the Serial Number: {serialNumber} was found to delete.");
                    return;
                }

                // Ask for confirmation before deleting
                if (AskForConfirmation())
                {
                    string response = service.Delete(serialNumber);

                    if (response != null)
                        UiTools.DataManipulationResponseView(response, "deleted");
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
                EndpointModel endpoint = service.Find(e => e.serialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
                if (endpoint == null)
                {
                    Console.WriteLine($"No endpoint with the Serial Number: {serialNumber} was found.");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Endpoint founded:\n");
                    UiTools.PrintEndpointView(endpoint);
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
            UiTools.AskForConfirmationView();
            int optionSelected;
            try
            {
                optionSelected = Convert.ToInt32(Console.ReadLine());
                return optionSelected == 1 ?  true : false;
            }
            catch
            {
                throw new ConvertMenuException("Please type a correct number");
            }
        }

        /// <summary>
        ///     Shows the options and retrieve the selected one
        /// </summary>
        public int OptionsMenu()
        {
            UiTools.OptionsMenuView();
            try
            {
                int optionSelected = Convert.ToInt32(Console.ReadLine());
                return optionSelected;
            }
            catch
            {
                throw new ConvertMenuException("Please type a correct number");
            }
        }
    }
}
