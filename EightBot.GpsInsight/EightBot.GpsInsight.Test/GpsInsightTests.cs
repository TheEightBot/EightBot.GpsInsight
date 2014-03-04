using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightBot.GpsInsight.Test
{
    [TestClass]
    public class GpsInsightTests
    {
        [TestMethod]
        public async Task AuthTestAsync()
        {
            var serviceClient = await ServiceClient.CreateServiceClientAsync("aldridgeapp", "52f50a0124dcf");
            Assert.IsNotNull(serviceClient);
        }

        [TestMethod]
        public async Task GetVehiclesTestAsync()
        {
            var serviceClient = await ServiceClient.CreateServiceClientAsync("aldridgeapp", "52f50a0124dcf");
            var vehicles = await serviceClient.GetVechiclesAsync();
            Assert.IsNotNull(vehicles);
            Assert.IsTrue(vehicles.Any());
        }

        [TestMethod]
        public async Task GetVehicleRuntimeTestAsync()
        {
            var serviceClient = await ServiceClient.CreateServiceClientAsync("aldridgeapp", "52f50a0124dcf");
            var vehicleRuntime = await serviceClient.GetVechicleRuntimeAsync("10033");
            Assert.IsNotNull(vehicleRuntime);
            Assert.IsTrue(vehicleRuntime.Any());
        }
    }
}
