using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.MovingBlockDTO
{
    public class MovingBlockWithBlockItemForListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int? Points { get; set; }
        public int? ExamId { get; set; }

        public virtual ICollection<BlockItemDTO> BlockItem { get; set; }
    }
}
