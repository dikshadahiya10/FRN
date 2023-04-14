using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public long ProductId { get; set; }

    public long UserId { get; set; }

    public long Quantity { get; set; }

    public bool? IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
