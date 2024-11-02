using System;

namespace LandisGyrProject.Exceptions
{
    public class EndpointException : Exception
    {
        public EndpointException() { }
        public EndpointException(string message) : base(message) { }
        public EndpointException(string message, Exception innerException): base(message, innerException) { }
    }
}