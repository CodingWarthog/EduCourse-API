using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseEnrolmentDTO
{
    public class CourseEnrolmentGetDTOs
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public ICollection<EnrolmentsDTOs> CourseEnrolments { get; set; }
    }
}
