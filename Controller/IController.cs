using System;

namespace LandisGyrProject.Controller
{
    public interface IController
    {
        void Create();
        void ListAll();
        void Update();
        void Delete();
        void Find();
    }
}
