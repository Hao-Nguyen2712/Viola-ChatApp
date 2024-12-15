using System;
using System.Collections.Generic;

namespace Viola.Domain.Entities;

public partial class Friend
{
    public int Id { get; set; }

    public string ProviderId { get; set; } = null!;

    public string RequestId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual User Provider { get; set; } = null!;

    public virtual User Request { get; set; } = null!;
}
