using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Users
{
    public class StatiticsOverall
    {
        public int numberOfCourse { get; set; }
        public int numberOfExams { get; set; }
        public int numberOfSets { get; set; }
        public int numberOfEMaterials { get; set; }
        public int numberOfERegisteredUsers { get; set; }
        public int numberOfCategory { get; set; }
        public int numberOfBadges { get; set; }
    }
}