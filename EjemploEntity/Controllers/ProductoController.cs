﻿using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto; //en el controller se hace la inyeccion con la interface

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }

        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<Respuesta> GetListaProductos(int productoID , float precio)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID, precio);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
