using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExperienceDTO
{
    public class UserExperienceDTO
    {
        public int Id { get; set; }
        public virtual ICollection<ExperienceForListDTO> Experience { get; set; }
    }
}
