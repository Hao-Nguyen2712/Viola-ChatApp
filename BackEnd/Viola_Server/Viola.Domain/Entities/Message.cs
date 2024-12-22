using System;
using System.Collections.Generic;

namespace Viola.Domain.Entities;

public partial class Message
{
    public int MessageId { get; set; }

    public string MessageText { get; set; } = null!;

    public DateTime SendAt { get; set; }

    public bool ReadStatus { get; set; }

    public int FromUid { get; set; }

    public int ToUid { get; set; }

    public virtual User FromU { get; set; } = null!;

    public virtual User ToU { get; set; } = null!;
}
