using System;

namespace LandisGyrProject.Exceptions
{
    public class EndpointNotFoundException : EndpointException
    {
        public EndpointNotFoundException() { }
        public EndpointNotFoundException(string message): base(message) { }
        public EndpointNotFoundException(string message, Exception innerException): base(message, innerException) { }
    }
}