using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class BadgeAssignment
    {
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Badges Badge { get; set; }
        public virtual User User { get; set; }
    }
}
