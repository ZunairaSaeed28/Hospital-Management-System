using System;
using System.Collections.Generic;

namespace MyMvcApp.Models;

public partial class Billing
{
    public int BillId { get; set; }

    public int? PatientId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentStatus { get; set; }
}
