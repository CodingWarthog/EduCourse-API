using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BadgeDTO
{
    public class UserForBadgeDTO
    {
        public int Id { get; set; }
        public virtual ICollection<BadgeAssignmentDTO> BadgeAssignment { get; set; }
    }
}
