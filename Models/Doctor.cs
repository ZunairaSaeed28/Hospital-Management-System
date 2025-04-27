using System;
using System.Collections.Generic;

namespace MyMvcApp.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialization { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }
}
