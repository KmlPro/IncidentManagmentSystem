using System;
using System.Collections.Generic;

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class Attachment
    {
        public Guid DraftApplicationId { get; set; }
        public int Id1 { get; set; }
        public string FileName { get; set; }

        public virtual DraftApplication DraftApplication { get; set; }
    }
}
