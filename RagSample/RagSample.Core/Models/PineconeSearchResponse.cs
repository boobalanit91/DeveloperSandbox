using System.Text.Json.Serialization;
namespace RagSample.Core.Models
{
    public class PineconeSearchResponse
    {
        [JsonPropertyName("matches")]
        public List<PineconeMatch> Matches { get; set; } = [];

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; } = string.Empty;

        [JsonPropertyName("usage")]
        public PineconeUsage Usage { get; set; } = new();
    }

    public class PineconeMatch
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("_score")]
        public double Score { get; set; }

        [JsonPropertyName("chunk_text")]
        public string ChunkText { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }

    public class PineconeUsage
    {
        [JsonPropertyName("read_units")]
        public int ReadUnits { get; set; }

        [JsonPropertyName("egress_bytes")]
        public long EgressBytes { get; set; }
    }
}
