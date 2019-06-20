using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseDTO
{
    public class UserCoursesDTO
    {
        public string Id { get; set; }
        // public string Lastname { get; set; }
        public ICollection<CourseForAddDTO> Course { get; set; }
    }
}
