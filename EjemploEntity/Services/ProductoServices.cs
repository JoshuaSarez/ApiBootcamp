using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EjemploEntity.DTOs;
using EjemploEntity.Utilitarios;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

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
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ProductoServices", "GetListaProductos", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x=> x.ProductoId).Select(x=> x.ProductoId).FirstOrDefault(); // primero se ordena (OrderByDescending) luego se seelecciona la columna(x=> x.ProductoId) y luego se escoge el valor que queremos en este caso el primer (Select(x=> x.ProductoId).FirstOrDefault())
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
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ProductoServices", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                //bool comparar = _context.Productos.Where(x => x.ProductoId == producto.ProductoId).Any();
                _context.Productos.Update(producto);//Actualiza
                await _context.SaveChangesAsync(); //commit

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizo correctamente el producto";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ProductoServices", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
