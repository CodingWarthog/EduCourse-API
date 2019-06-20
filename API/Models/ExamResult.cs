using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class ExamResult
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public int Points { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int TotalExamPoints { get; set; }
        public int Percentage { get; set; }
        public string ExamName { get; set; }


        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
    }
}
