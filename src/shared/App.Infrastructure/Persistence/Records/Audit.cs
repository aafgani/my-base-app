using System;
using System.Collections.Generic;

namespace App.Infrastructure.Persistence.Records;

public partial class Audit
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Action { get; set; } = null!;

    public string? Values { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
