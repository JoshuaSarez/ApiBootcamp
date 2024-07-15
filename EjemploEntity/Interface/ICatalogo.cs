using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interface
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> GetMarca();
        Task<Respuesta> GetModelo();
        Task<Respuesta> GetSucursal();
        Task<Respuesta> GetCiudad();
        Task<Respuesta> GetCaja();
        //Post
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PostMarca(Marca marca);
        Task<Respuesta> PostModelo(Modelo modelo);
        Task<Respuesta> PostSucursal(Sucursal sucursal);
        Task<Respuesta> PostCiudad(Ciudad ciudad);
        Task<Respuesta> PostCaja(Caja caja);

        //PUT
        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> PutMarca(Marca marca);
        Task<Respuesta> PutModelo(Modelo modelo);
        Task<Respuesta> PutSucursal(Sucursal sucursal);
        Task<Respuesta> PutCiudad(Ciudad ciudad);
        Task<Respuesta> PutCaja(Caja caja);

        //DELETE
        //Task<Respuesta> DeleteCategoria(int categoriaId);
    }
}
