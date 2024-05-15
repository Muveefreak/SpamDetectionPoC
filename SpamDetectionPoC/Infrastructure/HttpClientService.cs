using System;

namespace SpamDetectionPoC.Infrastructure
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync(string url, HttpContent content);
    }

    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        public string baseUrl;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetAsync(string action)
        {
            var url = baseUrl + action;
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string action, HttpContent content)
        {
            var url = baseUrl + action;
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
