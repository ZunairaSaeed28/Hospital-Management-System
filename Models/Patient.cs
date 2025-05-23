﻿using System;
using System.Collections.Generic;

namespace MyMvcApp.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }
}
