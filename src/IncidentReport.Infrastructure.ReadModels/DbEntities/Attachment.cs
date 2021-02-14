using System;

#nullable disable

namespace IncidentReport.ReadModels.DbEntities
{
    public partial class Attachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? DraftApplicationId { get; set; }
        public Guid? IncidentApplicationId { get; set; }

        public virtual DraftApplication DraftApplication { get; set; }
        public virtual IncidentApplication IncidentApplication { get; set; }
    }
}
