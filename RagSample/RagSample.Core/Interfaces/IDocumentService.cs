using Microsoft.AspNetCore.Http;

namespace RagSample.Core.Interfaces
{
    public interface IDocumentService
    {
        public Task<bool> UploadAsync(IFormFile uploadedFile, string category, CancellationToken cancellationToken);
        public Task<string> AskAsync(string userQuery, CancellationToken cancellationToken);
    }
}
