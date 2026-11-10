using System.Net.Http.Headers;

namespace RagSample.Api.Extensions
{
    public static class HttpClientExtension
    {
        public  static IServiceCollection AddHttpClients(this IServiceCollection services,IConfiguration _configuration)
        {
            services.AddHttpClient("LlmService", (http) =>
            {
                http.BaseAddress = new Uri(_configuration["Llm:BaseUrl"]!);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["Llm:ApiToken"]);
            });

            services.AddHttpClient("PineconeService", (http) =>
            {
                var apiHost = _configuration["DbConnection:PineconeApiHost"];
                var apiKey = _configuration["DbConnection:PineconeApiKey"];
                http.DefaultRequestHeaders.Add("Api-Key", apiKey);
                http.DefaultRequestHeaders.Add("X-Pinecone-API-Version", "2026-07");
                http.BaseAddress = new Uri(apiHost!);
            });

            return services;
        }
    }
}
