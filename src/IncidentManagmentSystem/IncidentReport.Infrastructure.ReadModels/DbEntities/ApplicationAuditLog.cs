﻿using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class ApplicationAuditLog
    {
        public string Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string EntityId { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
    }
}
