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

        public async Task<List<JawabanTracerAlumni>> GetPertanyaan(string idpertanyaan)
        {
            ListJawabanTracerAlumni data = null;
            var uri = new Uri($"{Helpers.Pengaturan.BaseUrl}/tracerstudyalumni?id_pertanyaan={idpertanyaan}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ListJawabanTracerAlumni>(content);
                }
                return data.CONTENT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SimpanTracerAlumni> Insert(TambahTracerAlumni tambahtracer)
        {
            var uri = new Uri($"{Helpers.Pengaturan.BaseUrl}/tracerstudyalumni/add");
            try
            {
                var json = JsonConvert.SerializeObject(tambahtracer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri,content);
                if (!response.IsSuccessStatusCode) {
                    throw new Exception("Tambah data gagal !"); 
                }else
                {
                    var dataresponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SimpanTracerAlumni>(dataresponse.ToString());
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }


}

