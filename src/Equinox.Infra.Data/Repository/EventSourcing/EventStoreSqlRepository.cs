using Equinox.Domain.Core.Events;
using Equinox.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSqlRepository : 
        IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;
        
        public EventStoreSqlRepository(EventStoreSqlContext 
            context)
        {
            _context = context;
        }

        public IList<StoredEvent> All (int aggregateId)
        {
            return (from e in _context.StoredEvent
                    where e.AggregateId == aggregateId
                    select e).ToList();
        }
       
        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}