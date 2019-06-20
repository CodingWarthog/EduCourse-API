using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class UserForExamsDTO
    {
        public string Id { get; set; }
        // public string Lastname { get; set; }
        public ICollection<CourseForExamsDTO> MyCourseExams { get; set; }
    }
}
