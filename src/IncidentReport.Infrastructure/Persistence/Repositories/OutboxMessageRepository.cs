using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Infrastructure.Persistence.NoDomainEntities;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class OutboxMessageRepository
    {
        private readonly IncidentReportWriteDbContext _writeContext;

        public OutboxMessageRepository(IncidentReportWriteDbContext writeContext)
        {
            this._writeContext = writeContext;
        }

        public async Task Create(OutboxMessage outboxMessage, CancellationToken cancellationToken)
        {
            if (outboxMessage == null)
            {
                throw new ArgumentNullException(nameof(outboxMessage));
            }

            await this._writeContext.OutboxMessage.AddAsync(outboxMessage, cancellationToken);
        }

        public OutboxMessage Get(Guid messageId)
        {
            var message = this._writeContext.OutboxMessage.FirstOrDefault(x => x.Id == messageId);
            return message;
        }
    }
}
