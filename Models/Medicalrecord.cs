using System;
using System.Collections.Generic;

namespace MyMvcApp.Models;

public partial class Medicalrecord
{
    public int RecordId { get; set; }

    public int? PatientId { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescription { get; set; }

    public DateOnly? VisitDate { get; set; }
}
