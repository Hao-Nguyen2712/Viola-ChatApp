using System;
using System.Collections.Generic;

namespace Viola.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Status { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Friend> FriendProviders { get; set; } = new List<Friend>();

    public virtual ICollection<Friend> FriendRequests { get; set; } = new List<Friend>();

    public virtual ICollection<Message> MessageFromUs { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageToUs { get; set; } = new List<Message>();
}
