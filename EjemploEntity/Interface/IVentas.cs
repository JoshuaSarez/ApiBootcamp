using EjemploEntity.Models;

namespace EjemploEntity.Interface
{
    public interface IVentas
    {
        Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, string? vendedor, double? precio, int clienteId);
    }
}
