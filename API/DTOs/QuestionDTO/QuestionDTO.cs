using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.QuestionDTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
        public string ImageUrl { get; set; }
        public int ExamId { get; set; }
    }
}
