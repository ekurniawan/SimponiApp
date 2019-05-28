using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimponiApp.Helpers;
using SimponiApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimponiApp.Services
{
    public class LowonganService
    {
        private HttpClient _client;
        public List<Lowongan> ListLowongan { get; set; }
        public LowonganService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<List<Lowongan>> GetAllData()
        {
            ListLowongan data = null;
            var uri = new Uri("http://api.uajy.ac.id/apisimponi/api/lowongan");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cleaning = JsonConvert.DeserializeObject(content);
                    JObject json = JObject.Parse(cleaning.ToString());

                    data = JsonConvert.DeserializeObject<ListLowongan>(json.ToString());
                }
                return data.CONTENT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
