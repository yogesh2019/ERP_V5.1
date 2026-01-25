using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Domain.Common
{
    public abstract class AggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvent = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvent => _domainEvent.AsReadOnly();
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvent.Clear();
        }
    }
}
