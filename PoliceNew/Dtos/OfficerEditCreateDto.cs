using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceNew.Dtos
{
    public class OfficerEditCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int? DepartmentId { get; set; }
    }
}
