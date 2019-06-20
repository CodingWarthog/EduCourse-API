using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.MovingBlockDTO
{
    public class MovingBlockForAddDTO
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public int? Points { get; set; }
        public int? ExamId { get; set; }
    }
}
