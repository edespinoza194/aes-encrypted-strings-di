using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class Tracking
{
    public int Tid { get; set; }

    public int Uid { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public DateTime Regdate { get; set; }
}
