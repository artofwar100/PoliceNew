﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceNew.Data.Entites
{
    public class Officers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
