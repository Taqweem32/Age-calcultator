using System;
using System.Collections.Generic;

namespace DBMS.Models;

public partial class Patient
{
    public int Patientid { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }
}
