using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class KursGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
        public int? UserId { get; set; }

        public ICollection<ExamGetDTO> Exam { get; set; }
    }
}
