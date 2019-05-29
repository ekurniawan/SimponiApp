using Newtonsoft.Json;
using SimponiApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimponiApp.Services
{
    public class TracerStudyService
    {
        private HttpClient _client;
        public TracerStudyService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }
        //menampilkan data pertanyaan
        public async Task<List<TracerAlumni>> GetAll(string idalumni)
        {
            ListTracerAlumni data = null;
            var uri = new Uri($"{Helpers.Pengaturan.BaseUrl}/tracerstudyalumni?id_alumni={idalumni}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ListTracerAlumni>(content);
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
