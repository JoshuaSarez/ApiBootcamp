using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interface
{
    public interface IVentas
    {
        Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, string? vendedor, double? precio, int clienteId);
        Task<Respuesta> PostVenta(Venta venta);
        Task<Respuesta> PutVenta(Venta venta);
    }
}
