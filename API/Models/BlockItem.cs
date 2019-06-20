using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class BlockItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BlockPosition { get; set; }
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
