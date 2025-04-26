using System;
using System.Collections.Generic;

namespace DBMS.Models;

public partial class PatientDoctor
{
    public int? Patientid { get; set; }

    public int? Doctorid { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
