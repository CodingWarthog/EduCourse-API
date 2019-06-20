using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamResultDTO
{
    public class QuestionResultDTO
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public int QuestionId { get; set; }
        public int ExamResultId { get; set; }
    }
}
