using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interface
{
    public interface ICliente
    {
        Task<Respuesta> GetListaClientes(int clienteId, string? clienteName, double identificacion);
        //Task<Respuesta> PostCliente(Cliente cliente);

    }
}
