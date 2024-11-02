using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandisGyrProject.Exceptions
{
    public class DuplicateSerialNumberException : EndpointException
    {
        public DuplicateSerialNumberException() { }
        public DuplicateSerialNumberException(string message): base(message) { }
        public DuplicateSerialNumberException(string message, Exception innerException): base(message, innerException) { }
    }
}
