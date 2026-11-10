using RagSample.Core.Interfaces;
using RagSample.Core.Models;
using System.Text;
using System.Text.Json;

namespace RagSample.Infrastructure.ApiClients
{
    public class PineconeApiClient(IHttpClientFactory _httpClientFactory) : IVectorDbApiClient
    {
        private readonly string yourNamespace = "zionelection";

        public async Task<bool> SaveDataAsync(List<string> chunks, string fileName, CancellationToken cancellationToken)
        {
            List<object> docList = new();

            foreach (var chunk in chunks)
            {
                docList.Add(new
                {
                    _id = Guid.NewGuid().ToString().Replace("-", "").Replace("_", ""),
                    chunk_text = chunk,
                    title = fileName
                });
            }

            using HttpClient client = _httpClientFactory.CreateClient("PineconeService");
            var response = await client.PostAsJsonAsync($"namespaces/{yourNamespace}/documents/upsert", new { documents = docList }, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                string rawErrorBody = await response.Content.ReadAsStringAsync();
                JsonSerializer.Deserialize<PineconeErrorResponse>(rawErrorBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return true;
        }

        public async Task<IEnumerable<string>?> RetrieveDataAsyc(string query, CancellationToken cancellationToken)
        {
            using HttpClient client = _httpClientFactory.CreateClient("PineconeService");
            PineconeRequestModel pineconeRequestModel = new PineconeRequestModel
            {
                Top_K = 3,
                Namespace = yourNamespace,
                Score_By = [
                    new ScoreByModel
                    {
                        Fields = ["chunk_text"],
                        Query = query,
                        Type = "text"
                    }
                ],
                Include_Fields = ["*"]
            };

            using var content = new StringContent(JsonSerializer.Serialize(pineconeRequestModel), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"namespaces/{yourNamespace}/documents/search", content, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                string rawErrorBody = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"Pinecone API failed. Status: {(int)response.StatusCode}, Error: {rawErrorBody}",
                    null,
                    response.StatusCode);
            }

            var resultStr = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(resultStr))
            {

                var result = JsonSerializer.Deserialize<PineconeSearchResponse>(resultStr);

                if (result?.Matches?.Any() == false)
                {
                    return null;
                }

                var matchingResults = result?.Matches.Select(x => x.ChunkText);

                return matchingResults;
            }

            return null;
        }

    }
}
