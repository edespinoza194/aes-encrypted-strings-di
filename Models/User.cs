using System;
using System.Collections.Generic;

namespace Tracker.Models;

public partial class User
{
    public int Uid { get; set; }

    public string Name { get; set; } = null!;

    public string Custno { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Gid { get; set; }

    public DateTime Regdate { get; set; }

    public string Token { get; set; } = null!;

    public int Status { get; set; }
}
