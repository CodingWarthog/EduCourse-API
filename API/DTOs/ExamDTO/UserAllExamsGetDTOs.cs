using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ExamDTO
{
    public class UserAllExamsGetDTOs
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<KursGetDTO> Course { get; set; }
    }
}
