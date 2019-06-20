using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Category
    {
        public Category()
        {
            Badges = new HashSet<Badges>();
            Course = new HashSet<Course>();
            Experience = new HashSet<Experience>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Badges> Badges { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
    }
}
