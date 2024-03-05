using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class Admin
{
    public int Aid { get; set; }

    public int Uid { get; set; }

    public DateTime Regdate { get; set; }

    public int Status { get; set; }
}
