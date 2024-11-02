using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandisGyrProject.Model
{
    public class EndpointModel
    {
        public string serialNumber { get; set; }
        public int meterModelId { get; set; }
        public int meterNumber { get; set; }
        public string meterFirmwareVersion { get; set; }
        public int switchState { get; set; }
    }
}
