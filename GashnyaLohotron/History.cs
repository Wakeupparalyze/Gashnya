using System;
using System.Collections.Generic;

namespace GashnyaLohotron;

public partial class History
{
    public int Id { get; set; }

    public int RewardId { get; set; }

    public int BannerId { get; set; }

    public virtual Banner Banner { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
