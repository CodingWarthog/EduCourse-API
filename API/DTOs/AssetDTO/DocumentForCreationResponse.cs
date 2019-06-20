using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AssetDTO
{
    public class DocumentForCreationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }

        public DocumentForCreationResponse()
        {
            DateCreated = DateTime.Now;
        }
    }
}
