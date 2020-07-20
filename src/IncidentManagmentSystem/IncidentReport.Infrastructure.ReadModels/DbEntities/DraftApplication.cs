using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class DraftApplication
    {
        public DraftApplication()
        {
            Attachment = new HashSet<Attachment>();
            SuspiciousEmployee = new HashSet<SuspiciousEmployee>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentTypeValue { get; set; }

        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<SuspiciousEmployee> SuspiciousEmployee { get; set; }
    }
}
