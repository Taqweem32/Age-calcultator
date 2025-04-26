using System;
using System.Collections.Generic;

namespace DBMS.Models;

public partial class PatientDisease
{
    public int? Patientid { get; set; }

    public int? Diseaseid { get; set; }

    public virtual Disease? Disease { get; set; }

    public virtual Patient? Patient { get; set; }
}
