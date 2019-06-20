using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamResultDTO
{
    public class ExamResultListDTO
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public int Points { get; set; }
        public int TotalExamPoints { get; set; }
        public int Percentage { get; set; }
        public string ExamName { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        
    }
}
