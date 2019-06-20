using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BadgeDTO
{
    public class BadgeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ExperiencePoints { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
