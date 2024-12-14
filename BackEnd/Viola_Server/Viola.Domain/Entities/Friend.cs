using System;
using System.Collections.Generic;

namespace Viola.Domain.Entities;

public partial class Friend
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public int RequestId { get; set; }

    public string Status { get; set; } = null!;

    public virtual User Provider { get; set; } = null!;

    public virtual User Request { get; set; } = null!;
}
