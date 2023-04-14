using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class OrderReceived
{
    public int Id { get; set; }

    public int OrderDetailId { get; set; }

    public long ProductId { get; set; }

    public int UserId { get; set; }

    public decimal Price { get; set; }

    public long Quantity { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual OrderDetail OrderDetail { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
