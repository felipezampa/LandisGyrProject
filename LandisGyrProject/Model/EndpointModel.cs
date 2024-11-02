using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandisGyrProject.Model.Enum;

namespace LandisGyrProject.Model
{
    public class EndpointModel
    {
        private string _serialNumber;
        private MeterModelId _meterModelId;
        private int _meterNumber;
        private string _meterFirmwareVersion;
        private SwitchState _switchState;

        public string SerialNumber
        {
            get => _serialNumber;
            set => _serialNumber = value;
        }

        public MeterModelId MeterModelId
        {
            get => _meterModelId;
            set => _meterModelId = value;
        }

        public int MeterNumber
        {
            get => _meterNumber;
            set => _meterNumber = value;
        }

        public string MeterFirmwareVersion
        {
            get => _meterFirmwareVersion;
            set => _meterFirmwareVersion = value;
        }

        public SwitchState SwitchState
        {
            get => _switchState;
            set => _switchState = value;
        }
    }

}
