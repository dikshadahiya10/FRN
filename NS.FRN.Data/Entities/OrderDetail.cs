using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public long BillValue { get; set; }

    public long PaymentModeId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<OrderReceived> OrderReceiveds { get; } = new List<OrderReceived>();
}
