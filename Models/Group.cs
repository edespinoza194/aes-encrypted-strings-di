using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class Group
{
    public int Gid { get; set; }

    public int Uid { get; set; }

    public int? Pid { get; set; }
}
