using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimponiApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimponiApp.Services
{
    public class LoginService
    {
        private HttpClient _client;
        public LoginService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Alumni> GetLogin(string username,string password)
        {
            WrapperAlumni wrapper = null;
            var uri = new Uri($"{Helpers.Pengaturan.BaseUrl}/alumni/{username}?pwd={password}");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cleaning = JsonConvert.DeserializeObject(content);
                    JObject json = JObject.Parse(cleaning.ToString());

                    wrapper = JsonConvert.DeserializeObject<WrapperAlumni>(json.ToString());
                }
                return wrapper.CONTENT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
