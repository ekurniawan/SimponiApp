
using Newtonsoft.Json;
using SimponiApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimponiApp.Services
{
    public class RestaurantServices
    {
        private HttpClient _client;
        public RestaurantServices()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Restaurant>> GetAll()
        {
            List<Restaurant> listRestaurant = new List<Restaurant>();
            var uri = new Uri("http://168.63.236.219/api/Restaurant");
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    listRestaurant = JsonConvert.DeserializeObject<List<Restaurant>>(content);
                }
                return listRestaurant;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(Restaurant restaurant)
        {
            var uri = new Uri("http://168.63.236.219/api/Restaurant");
            try
            {
                var json = JsonConvert.SerializeObject(restaurant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}