using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_V5_Domain.Inventory.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public bool IsDeleted => DeletedAt.HasValue;
    protected void MarkUpdated()
        => UpdatedAt = DateTime.UtcNow;

    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
        MarkUpdated();
    }

}

