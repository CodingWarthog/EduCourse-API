using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AssetDTO
{
    public class AssetListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
    }
}
