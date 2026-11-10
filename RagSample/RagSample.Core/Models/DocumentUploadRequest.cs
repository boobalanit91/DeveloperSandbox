using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RagSample.Core.Models
{
    public class DocumentUploadRequest
    {
        [Required]
        public IFormFile UploadedFile { get; set;  }

        [Required]
        public string Category { get; set; }
    }
}
