using System;
using System.Collections.Generic;

namespace DBMS.Models;

public partial class Doctor
{
    public int Doctorid { get; set; }

    public string? Doctorname { get; set; }

    public string? Speciality { get; set; }
}
