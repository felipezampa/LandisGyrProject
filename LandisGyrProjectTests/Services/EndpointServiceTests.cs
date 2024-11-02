using LandisGyrProject.Model.Enum;
using LandisGyrProject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace LandisGyrProject.Services.Tests
{
    [TestClass()]
    public class EndpointServiceTests
    {
        private EndpointService service;

        [TestInitialize]
        public void Setup()
        {
            service = new EndpointService();
        }

        [TestMethod]
        public void CreateTest()
        {
            // Simulate user input for the Create method
            var input = "123abc\n1.0\n123\n19\n1\n";
            var reader = new StringReader(input);
            Console.SetIn(reader); // Redirect Console.ReadLine to use the simulated input

            var newEndpoint = new EndpointModel();
            var result = service.Create(newEndpoint);

            Assert.IsNotNull(result);
            Assert.AreEqual("123abc", result);
        }

        [TestMethod]
        public void ListAllTest()
        {
            // Simulate input for the first Create call
            var input1 = "123abc\n1.0\n123\n19\n1\n";
            var reader1 = new StringReader(input1);
            Console.SetIn(reader1);
            var endpoint1 = new EndpointModel();
            service.Create(endpoint1);

            // Simulate input for the second Create call
            var input2 = "456def\n2.0\n456\n18\n2\n";
            var reader2 = new StringReader(input2);
            Console.SetIn(reader2);
            var endpoint2 = new EndpointModel();
            service.Create(endpoint2);

            var result = service.ListAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            CollectionAssert.Contains(result.ToList(), endpoint1);
            CollectionAssert.Contains(result.ToList(), endpoint2);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Set up initial input to simulate user input for SwitchState
            var initialInput = "123abc\n1.0\n123\n19\n1\n";
            var reader = new StringReader(initialInput);
            Console.SetIn(reader);
            // Creating endpoint
            var newEndpoint = new EndpointModel();
            service.Create(newEndpoint);
            // Editing ednpoint
            var updateInput = "0\n"; 
            var updateReader = new StringReader(updateInput);
            Console.SetIn(updateReader);

            var result = service.Update(newEndpoint.SerialNumber, newEndpoint);

            Assert.AreEqual(newEndpoint.SerialNumber, result);
            Assert.AreEqual(SwitchState.Disconnected, newEndpoint.SwitchState);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Set up initial input to simulate user input for creating an endpoint
            var initialInput = "123abc\n1.0\n123\n19\n1\n"; 
            var reader = new StringReader(initialInput);
            Console.SetIn(reader);
            // Creating endpoint
            var newEndpoint = new EndpointModel();
            service.Create(newEndpoint);

            // Deleting endpoint
            var result = service.Delete(newEndpoint.SerialNumber);

            Assert.AreEqual(newEndpoint.SerialNumber, result); 
            Assert.IsNull(service.Find(newEndpoint.SerialNumber));
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Reset Console input after each test
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

    }
}