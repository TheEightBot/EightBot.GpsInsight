using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EightBot.GpsInsight.Model
{
    public class VehicleInfo
    {
        public string id { get; set; }
        public string vin { get; set; }
        public string label { get; set; }
        public object serial_number { get; set; }
    }
}
