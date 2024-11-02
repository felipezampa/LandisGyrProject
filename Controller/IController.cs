using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
