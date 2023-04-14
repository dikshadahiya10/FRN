using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class Product
{
    public long Id { get; set; }

    public long Category { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public bool IsEligibleForDiscount { get; set; }

    public string? Photo { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<OrderReceived> OrderReceiveds { get; } = new List<OrderReceived>();
}
