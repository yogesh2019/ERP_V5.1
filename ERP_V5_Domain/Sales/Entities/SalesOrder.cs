using ERP_V5_Domain.Common;
using ERP_V5_Domain.Sales.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Domain.Sales.Entities
{
    public sealed class SalesOrder : AggregateRoot
    {
        public Guid id { get; private set; }
        public bool IsConfirmed { get; private set; }
        public void Confirm()
        {
            if (IsConfirmed)
            {
                throw new InvalidOperationException("Sales order is alreadly confirmed");
            }
            IsConfirmed = true;
            AddDomainEvent(new SalesOrderConfirmedEvent(id));
        }
    }
}
