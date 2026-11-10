namespace RagSample.Core.Models
{
    public class OpenRouterResponse
    {
        public string? Id { get; set; }

        public string? Object { get; set; }

        public long Created { get; set; }

        public string? Model { get; set; }

        public string? Provider { get; set; }

        public string? SystemFingerprint { get; set; }

        public string? ServiceTier { get; set; }

        public List<Choice>? Choices { get; set; }

        public Usage? Usage { get; set; }
    }

    public class Choice
    {
        public int Index { get; set; }

        public object? Logprobs { get; set; }

        public string? FinishReason { get; set; }

        public string? NativeFinishReason { get; set; }

        public Message? Message { get; set; }
    }

    public class Message
    {
        public string? Role { get; set; }

        public string? Content { get; set; }

        public string? Refusal { get; set; }

        public string? Reasoning { get; set; }

        public List<ReasoningDetail>? ReasoningDetails { get; set; }
    }

    public class ReasoningDetail
    {
        public string? Type { get; set; }

        public string? Text { get; set; }

        public string? Format { get; set; }

        public int Index { get; set; }
    }

    public class Usage
    {
        public int PromptTokens { get; set; }

        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }

        public decimal Cost { get; set; }

        public bool IsByok { get; set; }

        public PromptTokensDetails? PromptTokensDetails { get; set; }

        public CostDetails? CostDetails { get; set; }

        public CompletionTokensDetails? CompletionTokensDetails { get; set; }
    }

    public class PromptTokensDetails
    {
        public int CachedTokens { get; set; }

        public int CacheWriteTokens { get; set; }

        public int AudioTokens { get; set; }

        public int VideoTokens { get; set; }
    }

    public class CostDetails
    {
        public decimal UpstreamInferenceCost { get; set; }

        public decimal UpstreamInferencePromptCost { get; set; }

        public decimal UpstreamInferenceCompletionsCost { get; set; }
    }

    public class CompletionTokensDetails
    {
        public int ReasoningTokens { get; set; }

        public int ImageTokens { get; set; }

        public int AudioTokens { get; set; }
    }
}
