using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public int TotalExamPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
