using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class ExamBlockDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int? TimeLimit { get; set; }
        public int TotalExamPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Level { get; set; }
        public int CourseId { get; set; }
        public ICollection<BlocksForExamDTO> BlockItem { get; set; }
    }
}
