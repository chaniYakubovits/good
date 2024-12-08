using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ex2.Models;

public partial class Tasks
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Priority { get; set; }

    public DateOnly DueDate { get; set; }

    public string? Status { get; set; }

    public int? ProjectId { get; set; }

    public int? UserId { get; set; }

    public int? AttachmentsId { get; set; }

    public virtual Attachment? Attachments { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Users? User { get; set; }
}
