﻿using System.Collections.Generic;

namespace SSTest2.Model
{
    public class Offering
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Department> Departments { get; set; }

    }
}