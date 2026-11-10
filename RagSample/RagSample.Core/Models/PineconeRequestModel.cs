using System.Text.Json.Serialization;

namespace RagSample.Core.Models
{
    public class PineconeRequestModel
    {
        [JsonPropertyName("top_k")]
        public int Top_K { get; set; }

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; } = string.Empty;

        [JsonPropertyName("score_by")]
        public List<ScoreByModel> Score_By { get; set; } = [];

        [JsonPropertyName("include_fields")]
        public List<string> Include_Fields { get; set; } = [];
    }

    public class ScoreByModel
    {
        [JsonPropertyName("fields")]
        public List<string> Fields { get; set; } = [];

        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
    }
}
