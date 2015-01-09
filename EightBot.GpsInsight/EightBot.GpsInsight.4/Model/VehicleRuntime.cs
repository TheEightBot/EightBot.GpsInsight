using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightBot.GpsInsight.Model
{
    public class VehicleRuntime
    {
        public string id { get; set; }
        public string vin { get; set; }
        public string label { get; set; }
        public long serial_number { get; set; }
        public int age_minutes { get; set; }
        public string fix_time { get; set; }
        public double odometer { get; set; }
        public string runtime_hours { get; set; }
        public string runtime_lifetime { get; set; }
        public string runtime_desc { get; set; }
    }
}