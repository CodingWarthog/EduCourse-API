using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Users
{
    public class PersonalStatistics
    {
        public int numberOfEnrolmentCourses { get; set; }
        public int numberOfEnrolmentExams { get; set; }
        public int numberOfAddedMaterials { get; set; }
        public int numberOfAddedCourses { get; set; }
        public int numberOfAssignedBadges { get; set; }
    }
}
