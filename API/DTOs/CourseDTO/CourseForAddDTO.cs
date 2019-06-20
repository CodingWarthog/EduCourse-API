using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseDTO
{
    public class CourseForAddDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Other { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }

       
    }
}
