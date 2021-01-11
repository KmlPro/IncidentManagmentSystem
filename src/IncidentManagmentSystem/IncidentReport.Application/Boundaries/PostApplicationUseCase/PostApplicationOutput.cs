using System;

namespace IncidentReport.Application.Boundaries.PostApplicationUseCase
{
    public class PostApplicationOutput
    {
        public PostApplicationOutput(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.Id = id;
        }

        public Guid Id { get; }
    }
}
