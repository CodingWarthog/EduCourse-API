using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseEnrolmentDTO
{
    public class EnrolDTO
    {
        public DateTime EnrolmentDate { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
