using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AssetDTO
{
    public class UserAssetListDTO
    {
        public int Id { get; set; }
        public ICollection<AssetListDTO> Asset { get; set; }
    }
}
