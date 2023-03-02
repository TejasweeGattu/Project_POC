using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataAccess_Layer.Models;

public partial class Department
{
    public int Did { get; set; }

    public int Cid { get; set; }

    public string Dname { get; set; } = null!;

    public string Dhod { get; set; } = null!;

    public string Dblock { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual College CidNavigation { get; set; } = null!;
    
    [JsonIgnore]
    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
