using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class ContactDetail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public long ModifiedBy { get; set; }
}
