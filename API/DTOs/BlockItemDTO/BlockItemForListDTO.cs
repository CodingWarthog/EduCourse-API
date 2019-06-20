using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BlockItemDTO
{
    public class BlockItemForListDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? BlockPosition { get; set; }
        public int? ExamId { get; set; }
    }
}
