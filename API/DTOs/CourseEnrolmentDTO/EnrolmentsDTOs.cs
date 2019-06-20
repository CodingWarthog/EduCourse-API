using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseEnrolmentDTO
{
    public class EnrolmentsDTOs
    {
        public DateTime EnrolmentDate { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
    }
}
