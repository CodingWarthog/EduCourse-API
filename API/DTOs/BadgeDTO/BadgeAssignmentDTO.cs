using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BadgeDTO
{
    public class BadgeAssignmentDTO
    {
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual BadgeDTO Badge { get; set; }
    }
}
