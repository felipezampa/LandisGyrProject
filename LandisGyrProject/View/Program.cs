using System;
using LandisGyrProject.Controller;

namespace LandisGyrProject.View
{
    public class Program
    {
        static void Main(string[] args)
        {
            EndpointController controller = new EndpointController();
            UiViews.WelcomeMenuView();
            while (true)
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
                        if (controller.AskForConfirmation())
                            return;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }

    }
}
