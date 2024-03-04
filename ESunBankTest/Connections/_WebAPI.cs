using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace ESunBankTest.Connections
{
    public class _WebAPI
    {
        protected HttpClient httpClient = new HttpClient();

        public _WebAPI()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        protected string GetMethod(string Path, NameValueCollection Data)
        {
            return GetMethodAsync(Path, Data).Result;
        }

        protected async Task<string> GetMethodAsync(string Path, NameValueCollection Data)
        {
            string queryString = "";
            foreach (var item in Data.AllKeys)
            {
                if (string.IsNullOrEmpty(queryString))
                    queryString += $"{HttpUtility.UrlEncode(item)}={HttpUtility.UrlEncode(Data[item])}";
                else
                    queryString += $"&{HttpUtility.UrlEncode(item)}={HttpUtility.UrlEncode(Data[item])}";
            }
            string result = "";
            HttpResponseMessage response = await httpClient.GetAsync($"{Path}?{queryString}");
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;

            }
            return result;
        }

        protected string PostMethod(string Path, object Data)
        {
            return PostMethodAsync(Path, Data).Result;
        }

        protected async Task<string> PostMethodAsync(string Path, object Data)
        {
            string result = "";
            string StrObj = JsonConvert.SerializeObject(Data);
            var stringContent = new StringContent(
                StrObj
                , System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{Path}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;

            }
            return result;
        }



        private static SecurityProtocolType GetSecurityProtocol()
        {
            var result = 0;
            foreach (var value in Enum.GetValues(typeof(SecurityProtocolType)))
                result += (int)value;
            return (SecurityProtocolType)result;
        }
    }
}
