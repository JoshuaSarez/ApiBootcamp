﻿using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Ciudad
{
    public int CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }
}
