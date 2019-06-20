using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExperienceDTO
{
    public class ExperienceForListDTO
    {
        //public int Id { get; set; }
        public int? ExperiencePoints { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
