using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EightBot.GpsInsight.Model
{
    class Response<T> where T : class, new()
    {
        public Head Head { get; set; }

        [JsonProperty(propertyName: "data")]
        public T Content { get; set; }
    }
}
