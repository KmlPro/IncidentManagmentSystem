using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Users
{
    public class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        public UserId(Guid value)
        {
            this.Value = value;
        }
    }
}
