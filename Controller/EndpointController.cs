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
        /// Create a new endpoint and then informs if the operation went well
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
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get all of the endpoints and then call the action to print on screen every object
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
                    foreach (EndpointModel endpoint in endpoints)
                    {
                        UiTools.PrintEndpointView(endpoint);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            Console.WriteLine("---> Update an endpoint");
        }
        public void Delete()
        {
            Console.WriteLine("---> Delete an endpoint");
        }
        public void Find()
        {
        }

        public bool AskForConfirmation()
        {
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
