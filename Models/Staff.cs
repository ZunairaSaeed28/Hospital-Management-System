using System;
using System.Collections.Generic;

namespace MyMvcApp.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public string? ContactNumber { get; set; }
}
