using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BadgeDTO
{
    public class AssignBadgeDTO
    {
        public int UserId { get; set; }
        public int BadgeId { get; set; }
    }
}
