using System;
using System.Collections.Generic;

namespace GashnyaLohotron;

public partial class Banner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? BannerImg { get; set; }

    public int Price { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();
}
