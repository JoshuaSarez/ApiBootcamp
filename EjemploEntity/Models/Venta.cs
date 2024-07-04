using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Venta
{
    public int IdFactura { get; set; }

    public string? NumFact { get; set; }

    public DateTime? FechaHora { get; set; }

    public int ClienteId { get; set; }

    public int ProductoId { get; set; }

    public int ModeloId { get; set; }

    public int CategId { get; set; }

    public int MarcaId { get; set; }

    public int SucursalId { get; set; }

    public int CajaId { get; set; }

    public int VendedorId { get; set; }

    public double? Precio { get; set; }

    public int? Unidades { get; set; }

    public int? Estado { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
