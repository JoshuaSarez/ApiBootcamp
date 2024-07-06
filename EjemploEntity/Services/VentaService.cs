using EjemploEntity.DTOs;
using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentaService : IVentas
    {
		private readonly VentasContext _context;

		public VentaService (VentasContext context)
		{
			this._context = context;
		}


        public async Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, string? vendedor, double? precio, int clienteId)
        {
			var respuesta = new Respuesta();
			try
			{
                IQueryable<VentaDTO> query = (from v in _context.Ventas
                                               join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                               join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                               join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                               join ca in _context.Categoria on v.CategId equals ca.CategId
                                               join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                               join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                               join cj in _context.Cajas on v.CajaId equals cj.CajaId
                                               join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                               where v.Estado == 1
                                               select new VentaDTO
                                                {
                                                    IdFactura = v.IdFactura,
                                                    NumFact = v.NumFact,
                                                    FechaHora = v.FechaHora,//
                                                    ClienteId = cl.ClienteId,
                                                    ClienteDetalle = cl.ClienteNombre,
                                                    ProductoDetalle = pr.ProductoDescrip,
                                                    ModeloDetalle = mo.ModeloDescripción,
                                                    CategDetalle = ca.CategNombre,
                                                    MarcaDetalle = ma.MarcaNombre,
                                                    SucursalDetalle = su.SucursalNombre,
                                                    Caja = cj.CajaDescripcion,
                                                    Vendedor = ve.VendedorDescripcion,//
                                                    Precio = v.Precio,//
                                                    Unidades = v.Unidades,
                                                    Estado = v.Estado,//
                                                });
                respuesta.Cod = "000";
                //1
                if ((numFact != null || numFact != "0") && (fecha != null || fecha != "0") && (vendedor != null || vendedor != "0") && precio != 0 && clienteId != 0)
                {
                    query = query.Where(x => x.NumFact.Equals(numFact) && x.FechaHora.Equals(fecha) && x.Vendedor.Equals(vendedor) && x.Precio == precio);// && x.Estado == 1);
                }
                //2
                else if ((numFact != null || numFact != "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.NumFact.Equals(numFact));// && x.Estado == 1);
                }
                //3
                else if ((numFact == null || numFact == "0") && (fecha != null || fecha != "0") && (vendedor == null || vendedor == "0") && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.FechaHora.Equals(fecha));// && x.Estado == 1);
                }
                //4
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor != null || vendedor != "0") && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.Vendedor.Equals(vendedor));// && x.Estado == 1);
                }
                //5
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio != 0 && clienteId == 0)
                {
                    query = query.Where(x => x.Precio == precio);// && x.Estado == 1);
                }
                //6
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio == 0 && clienteId != 0)
                {
                    query = query.Where(x => x.ClienteId == clienteId);
                }
                //7
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.Estado == 1);
                }

                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }

			catch (Exception ex)
			{
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error:  {ex.Message}";
                
			}
			return respuesta;
        }

        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault();

                venta.IdFactura = Convert.ToInt32(query) + 1;
                venta.FechaHora = DateTime.Now;

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error:  {ex.Message}"; ;
            }
            return respuesta;
        }

        //public async Task<Respuesta> PutVenta(Venta venta)
        //{
        //    var respuesta = new Respuesta();
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        respuesta.Cod = "999";
        //        respuesta.Mensaje = $"Se presento un error:  {ex.Message}";
        //    }
        //    return respuesta;
        //}
        public async Task<Respuesta> GetVenta()
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.Where(x=> x.Precio == 100);
                respuesta.Cod = "000";
                respuesta.Data = await query
                    .GroupBy(x=> x.Precio)
                    .Select(g=> new 
                    { 
                        cantidadRegistros = g.Count(), 
                        vConsultado = g.Key
                    }).ToArrayAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error:  {ex.Message}";
            }
            return respuesta;
        }
    }
}
