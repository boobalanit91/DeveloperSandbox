namespace RagSample.Core.Interfaces
{
    public interface ILlmApiClient
    {
        Task<string> SendAsync(string prompt, IList<string> inputs, CancellationToken cancellationToken);
    }
}
