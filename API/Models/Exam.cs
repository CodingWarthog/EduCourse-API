using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Exam
    {
        public Exam()
        {
            BlockItem = new HashSet<BlockItem>();
            ExamResult = new HashSet<ExamResult>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public int TotalExamPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<BlockItem> BlockItem { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
