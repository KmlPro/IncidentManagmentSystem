﻿using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.Models
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
