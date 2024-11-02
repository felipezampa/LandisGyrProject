using System;
using LandisGyrProject.Controller;
using LandisGyrProject.Exceptions;

namespace LandisGyrProject.View
{
    public class Program
    {
        static void Main(string[] args)
        {
            EndpointController controller = new EndpointController();
            UiTools.WelcomeMenuView();
            while (true)
            {
                try
                {
                    switch (controller.OptionsMenu())
                    {
                        case 1:
                            controller.Create();
                            break;
                        case 2:
                            controller.Update();
                            break;
                        case 3:
                            controller.Delete();
                            break;
                        case 4:
                            controller.ListAll();
                            break;
                        case 5:
                            controller.Find();
                            break;
                        case 6:
                            if(controller.AskForConfirmation())
                                return;
                            break;
                        default:
                            Console.WriteLine("Please select a valid option.");
                            break;
                    }
                }
                catch (ConvertMenuException ex)
                {
                    Console.WriteLine($"Error {ex.Message}\nPlease try again.");
                }
            }
        }

    }
}
