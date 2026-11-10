using Microsoft.AspNetCore.Mvc;
using RagSample.Core.Interfaces;
using RagSample.Core.Models;
using System.Net;

namespace RagSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController(IDocumentService _documentService) : ControllerBase
    {
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadDocument([FromForm] DocumentUploadRequest documentUploadRequest, CancellationToken cancellationToken)
        {
            if (documentUploadRequest.UploadedFile == null || documentUploadRequest.UploadedFile.Length == 0)
                return BadRequest("Invalid file.");

            bool result = await _documentService.UploadAsync(
                documentUploadRequest.UploadedFile,
                documentUploadRequest.Category,
                cancellationToken);

            return result ? Ok(result) : BadRequest();
        }

        [HttpGet("ask/userQuery")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Ask([FromRoute] string userQuery, CancellationToken cancellationToken)
        {
            string result = await _documentService.AskAsync(userQuery, cancellationToken);
            return Ok(result);
        }
    }
}
