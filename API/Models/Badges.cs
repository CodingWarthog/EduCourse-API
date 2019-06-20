using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Badges
    {
        public Badges()
        {
            BadgeAssignment = new HashSet<BadgeAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperiencePoints { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<BadgeAssignment> BadgeAssignment { get; set; }
    }
}
