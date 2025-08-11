using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Group
{
    public class GroupCreateDto
    {
        public int Capacity { get; set; }
        public string Name { get; set; }
        public int EducationId { get; set; }
    }
}
