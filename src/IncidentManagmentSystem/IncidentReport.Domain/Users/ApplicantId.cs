using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Users
{
    public class UserId : ValueObject
    {
        public Guid Id { get; private set; }

        private UserId(Guid id)
        {
            this.Id = id;
        }

        public static UserId Create(Guid id)
        {
            return new UserId(id);
        }
    }
}
