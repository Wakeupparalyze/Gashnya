using System;
using System.Collections.Generic;

namespace GashnyaLohotron;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public int? UserBalance { get; set; }

    public string Login { get; set; } = null!;

    public int? HistoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual History? History { get; set; }
}
