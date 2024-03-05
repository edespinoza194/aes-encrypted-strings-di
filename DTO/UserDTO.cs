using System;
using System.Collections.Generic;

namespace Tracker.DTO;

public partial class UserDTO
{
    public int Uid { get; set; }

    public string Name { get; set; } = null!;

    public string Custno { get; set; } = null!;

    public DateTime Regdate { get; set; }

    public int Status { get; set; }
}
