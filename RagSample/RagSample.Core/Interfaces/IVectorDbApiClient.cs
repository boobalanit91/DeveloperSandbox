namespace RagSample.Core.Interfaces
{
    public interface IVectorDbApiClient
    {
        Task<bool> SaveDataAsync(List<string> chunks,string fileName, CancellationToken cancellationToken);
        Task<IEnumerable<string>?> RetrieveDataAsyc(string query, CancellationToken cancellationToken);
    }
}
