using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class Alert
{
    public int Aid { get; set; }

    public int Uid { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public DateTime Regdate { get; set; }

    public DateTime? Ddate { get; set; }

    public int? Did { get; set; }

    public int Status { get; set; }
}
