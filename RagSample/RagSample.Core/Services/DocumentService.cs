using LangChain.Splitters.Text;
using Microsoft.AspNetCore.Http;
using RagSample.Core.Interfaces;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace RagSample.Core.Services
{
    public class DocumentService(IVectorDbApiClient _vectorDbApiClient, ILlmApiClient _llmApiClient) : IDocumentService
    {
        public async Task<bool> UploadAsync(IFormFile uploadedFile, string category, CancellationToken cancellationToken)
        {
            
            IReadOnlyCollection<string> chunks = ChunkFileAsync(uploadedFile);

            if (chunks?.Count > 0)
            {
                var response = await _vectorDbApiClient.SaveDataAsync([.. chunks], category, cancellationToken);
                return response;
            }

            return false;
        }

        private static IReadOnlyList<string> ChunkFileAsync(IFormFile uploadedFile)
        {
            var textBuilder = new StringBuilder();
            using var stream = uploadedFile.OpenReadStream();

            using (PdfDocument document = PdfDocument.Open(stream))
            {
                foreach (Page page in document.GetPages())
                {
                    textBuilder.AppendLine(page.Text);
                }
            }

            int maxTokensPerChunk = 2000;
            var splitter = new RecursiveCharacterTextSplitter(chunkSize: maxTokensPerChunk, chunkOverlap: 200);

            return splitter.SplitText(textBuilder.ToString());
        }

        public async Task<string> AskAsync(string userQuery, CancellationToken cancellationToken)
        {
            IEnumerable<string>? vectorResponse = await _vectorDbApiClient.RetrieveDataAsyc(userQuery, cancellationToken);
            if (vectorResponse == null)
                throw new Exception("No matching results are found related to user query.");

            string llmResponse = await _llmApiClient.SendAsync(userQuery, [.. vectorResponse], cancellationToken);

            return llmResponse;

        }
    }
}
