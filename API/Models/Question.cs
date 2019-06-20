using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
