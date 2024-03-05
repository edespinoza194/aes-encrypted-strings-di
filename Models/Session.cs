using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class Session
{
    public int Sid { get; set; }

    public int Uid { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Regdate { get; set; }

    public int Status { get; set; }
}
