using Newtonsoft.Json;
using SimponiApp.Helpers;
using SimponiApp.Models;
using System;
using System.Collections.Generic;
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
            var uri = new Uri(Pengaturan.BaseUrl);
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ListLowongan>(content);
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
