using ERP_V5_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Domain.Sales.Events
{
    public sealed record SalesOrderConfirmedEvent(Guid SalesOrderId) : DomainEvent;
}
