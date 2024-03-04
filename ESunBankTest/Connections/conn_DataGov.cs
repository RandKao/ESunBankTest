using ESunBankTest.ViewModels.Connections;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace ESunBankTest.Connections
{
    public class conn_DataGov : _WebAPI
    {
        public conn_DataGov(IConfiguration config)
        {
            httpClient.BaseAddress = new Uri(config.GetValue<string>("DataGov:Url").ToString());
        }


        public List<vm_Data13223> GetData13223()
        {
            return GetData13223Async().Result;
        }
        public async Task<List<vm_Data13223>> GetData13223Async()
        {
            NameValueCollection queryString = [];
            var Str = await GetMethodAsync($"A17030000J-000011-06t", queryString);
            if (string.IsNullOrEmpty(Str))
                return null;
            var Result = JsonConvert.DeserializeObject<List<vm_Data13223>>(Str);
            return Result;
        }
    }
}
