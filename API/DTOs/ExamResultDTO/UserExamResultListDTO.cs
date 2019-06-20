using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamResultDTO
{
    public class UserExamResultListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public ICollection<ExamResultListDTO> ExamResult { get; set; }
    }
}
