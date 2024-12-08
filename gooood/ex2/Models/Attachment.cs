using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ex2.Models;

public partial class Attachment
{
    public string? Name { get; set; }
    [Key]
    public int Id { get; set; }

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
