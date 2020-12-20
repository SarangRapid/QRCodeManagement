using Newtonsoft.Json;
using QRCodeManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QRCodeManagement.Service.Class
{
    public class QRCodeManageService : IQRCodeManageService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public QRCodeManageService(IHttpClientFactory _httpClientFactory)
        {
            this.httpClientFactory = _httpClientFactory;
        }
        public async Task<Root> ReadQRCode(string path)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
          $"{ConfigSection.ConfigHelper.WebApiUrl}{path}");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var roots = JsonConvert.DeserializeObject<IEnumerable<Root>>(responseString);

                if (roots?.Any() ?? false)
                {
                    return roots?.FirstOrDefault();
                }
            }

            return null;
        }
    }
}
