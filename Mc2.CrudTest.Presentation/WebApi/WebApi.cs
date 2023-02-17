using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.WebApi
{
    public static class WebApi
    {

        public static IConfiguration config { get; }
        static WebApi()
        {
            config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        private static string webApiBaseUrl
        {
            get {

                return WebApi.config["webApiBaseUrl"];

            }
            set { }
        }

        public static T CallMethod<T>(string url, object model, string token, HttpMethod method) where T : new()
        {
            T res = new T();
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(string.Format("{0}{1}", webApiBaseUrl, url)),
                Method = method,
            };

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("Authorization", string.Format("Bearer {0}", token));
            }

            var json = JsonConvert.SerializeObject(model);
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;
                var task = client.SendAsync(request)
                    .ContinueWith((taskwithmsg) =>
                    {
                        var response = taskwithmsg.Result;
                        var jsonTask = response.Content.ReadAsStringAsync();
                        jsonTask.Wait();
                        var jsonObject = jsonTask.Result;
                        T result = JsonConvert.DeserializeObject<T>(jsonObject);
                        res = result;
                    });
                task.Wait();
                return res;
            }
        }
    }
}
