using Core.common;
using Newtonsoft.Json;
using Services.common;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StackOverflowApiService : IStackOverflowApiService
    {
        private readonly HttpClient _httpClient;

        public StackOverflowApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StackOverflowPost>> GetLatestQuestionsAsync(int pageSize)
        {
            var apiUrl = $"https://api.stackexchange.com/2.3/questions?order=desc&sort=activity&site=stackoverflow&pagesize={pageSize}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<StackOverflowApiResponse>(jsonString)?.Items;
                return posts;
            }
            else
            {
                // Handle unsuccessful API response
                throw new APIException(System.Net.HttpStatusCode.InternalServerError,"Failed to fetch data. Status code:");
            }
        }
    }

}
