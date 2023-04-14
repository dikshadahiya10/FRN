using System;
using System.Collections.Generic;

namespace NS.FRN.Data.Entities;

public partial class User
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long RoleId { get; set; }

    public int Age { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int Pincode { get; set; }

    public bool IsVerified { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ProfilePic { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
