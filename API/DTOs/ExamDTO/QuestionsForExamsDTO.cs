using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class QuestionsForExamsDTO
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
        public int ExamId { get; set; }
    }
}
