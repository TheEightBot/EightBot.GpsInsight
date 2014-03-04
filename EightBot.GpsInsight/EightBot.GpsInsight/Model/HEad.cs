using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightBot.GpsInsight.Model
{
    class Head
    {
        public string status { get; set; }
        public string method { get; set; }
        public string context { get; set; }
        public string request_time { get; set; }
        public object session_start { get; set; }
        public int request_count { get; set; }
        public string request_ip { get; set; }
        public double timer { get; set; }
        public string username { get; set; }
    }
}
