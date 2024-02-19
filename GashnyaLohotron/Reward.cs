using System;
using System.Collections.Generic;

namespace GashnyaLohotron;

public partial class Reward
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Chance { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? RewardImg { get; set; }

    public int? BannerId { get; set; }

    public virtual Banner? Banner { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
