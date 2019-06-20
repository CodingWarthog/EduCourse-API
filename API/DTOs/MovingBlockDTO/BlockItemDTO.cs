using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.MovingBlockDTO
{
    public class BlockItemDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? BlockPosition { get; set; }
        public int? MovingBlockId { get; set; }
    }
}
