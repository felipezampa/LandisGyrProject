using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandisGyrProject.Exceptions
{
    public class ConvertMenuException : Exception
    {
        public ConvertMenuException() { }

        public ConvertMenuException(string message)
            : base(message) { }

        public ConvertMenuException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
