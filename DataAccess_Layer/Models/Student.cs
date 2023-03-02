using System;
using System.Collections.Generic;

namespace DataAccess_Layer.Models;

public partial class Student
{
    public int Sid { get; set; }

    public int Did { get; set; }

    public string SfirstName { get; set; } = null!;

    public string? SmiddleName { get; set; }

    public string SlastName { get; set; } = null!;

    public DateTime Sdob { get; set; }

    public string Saddress { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual Department DidNavigation { get; set; } = null!;
}
