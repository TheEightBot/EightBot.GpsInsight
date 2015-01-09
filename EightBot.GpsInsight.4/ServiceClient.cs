using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EightBot.GpsInsight
{
    public class ServiceClient
    {
        private const string
            RestServiceBaseAddress = "http://api.gpsinsight.com/v2/",
            AcceptHeaderApplicationJson = "application/json";

        private string AuthToken;

        private HttpClient CreateRestClient()
        {
            var client = new HttpClient() { BaseAddress = new Uri(RestServiceBaseAddress) };

            client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(AcceptHeaderApplicationJson));

            return client;
        }


        private ServiceClient()
        {
        }

        public string LoginAsync(string username, string appToken)
        {
            var authInfo = GetAsync<Model.Response<Model.Token>>(String.Format("UserAuth/login?username={0}&app_token={1}", username, appToken));

            if (authInfo == null || authInfo.Content == null)
                return string.Empty;

            return authInfo.Content.token;
        }

        public Model.VehicleInfo GetVechicleAsync(string vehicleIdentifier)
        {
            var authInfo = GetAsync<Model.Response<List<Model.VehicleInfo>>>(String.Format("vehicle/read?vehicle={0}&token={1}", vehicleIdentifier, AuthToken));

            if (authInfo == null || authInfo.Content == null || !authInfo.Content.Any())
                return default(Model.VehicleInfo);

            return authInfo.Content.FirstOrDefault();
        }

        public IEnumerable<Model.VehicleInfo> GetVechiclesAsync()
        {
            var authInfo = GetAsync<Model.Response<List<Model.VehicleInfo>>>(String.Format("user/listvehicles?token={0}", AuthToken));

            if (authInfo == null || authInfo.Content == null)
                return Enumerable.Empty<Model.VehicleInfo>();

            return authInfo.Content;
        }

        public IEnumerable<Model.VehicleRuntime> GetVechicleRuntimeAsync(string vehicleIdentifier)
        {
            var runtimeInfo = GetAsync<Model.Response<List<Model.VehicleRuntime>>>(String.Format("vehicle/runtime?vehicle={0}&date={1}&token={2}", vehicleIdentifier, DateTime.Now.ToString(), AuthToken));

            if (runtimeInfo == null || runtimeInfo.Content == null)
                return Enumerable.Empty<Model.VehicleRuntime>();

            return runtimeInfo.Content;
        }


        private T GetAsync<T>(string path)
        {
            using (var client = CreateRestClient())
            {
                var getDataResponse = client.GetAsync(path, HttpCompletionOption.ResponseContentRead).Result;

                //If we do not get a successful status code, then return an empty set
                if (!getDataResponse.IsSuccessStatusCode)
                    return default(T);

                return JsonConvert.DeserializeObject<T>(getDataResponse.Content.ReadAsStringAsync().Result);
            }
        }


        public static ServiceClient CreateServiceClientAsync(string username, string appToken)
        {
            var serviceClient = new ServiceClient();
            serviceClient.AuthToken = serviceClient.LoginAsync(username, appToken);

            if (String.IsNullOrEmpty(serviceClient.AuthToken))
                throw new UnauthorizedAccessException("Invalid username or appToken provided");

            return serviceClient;
        }
    }
}