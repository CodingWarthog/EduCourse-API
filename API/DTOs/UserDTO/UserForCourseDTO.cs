using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.UserDTO
{
    public class UserForCourseDTO
    {
        public string Id { get; set; }
        // public string Lastname { get; set; }
        public ICollection<EnrolCourseDTO> CourseEnrolment { get; set; }
    }
}
