using System;

namespace LandisGyrProject.Exceptions
{
    public class DuplicateSerialNumberException : EndpointException
    {
        public DuplicateSerialNumberException() { }
        public DuplicateSerialNumberException(string message): base(message) { }
        public DuplicateSerialNumberException(string message, Exception innerException): base(message, innerException) { }
    }
}
