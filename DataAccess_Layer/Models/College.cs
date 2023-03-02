using System;
using System.Collections.Generic;

namespace DataAccess_Layer.Models;

public partial class College
{
    public int Cid { get; set; }

    public string Cname { get; set; } = null!;

    public string Caddress { get; set; } = null!;

    public string Czipcode { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedBy { get; set; }

    public string? ModifiedDate { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();
}
