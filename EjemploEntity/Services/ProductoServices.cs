using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EjemploEntity.DTOs;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto
    {
        private readonly VentasContext _context;
        public ProductoServices(VentasContext context) 
        {
            this._context = context;
        }
        public async Task<Respuesta> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new Respuesta();
            try
            {
                if (productoID == 0 && precio == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A")
                                            select new ProductoDto
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";

                }
                else if (productoID != 0 && precio == 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Estado.Equals("A")).ToListAsync();
                }
                else if (precio != 0 && productoID == 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
                else if (productoID != 0 && precio != 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error:  {ex.Message}";
            }

            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x=> x.ProductoId).Select(x=> x.ProductoId).FirstOrDefault(); // primero se ordena (order by) luego se seelecciona la columna y luego se escoge el valor que qeremos en este caso el primer
                producto.ProductoId = query + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync(); //commit

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error:  {ex.Message}";
                //throw;
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {

                _context.Productos.Update(producto);
                await _context.SaveChangesAsync(); //commit

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizo correctamente el producto";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
                //throw;
            }
            return respuesta;
        }
    }
}
