using EjemploEntity.DTOs;
using EjemploEntity.Interface;
using EjemploEntity.Models;
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


        public async Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, string? vendedor, double? precio)
        {
			var respuesta = new Respuesta();
			try
			{
                //List<VentaDTO> query = new List<VentaDTO>();
                IEnumerable<VentaDTO> query = (from v in _context.Ventas
                             //join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                             //join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                             //join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                             //join ca in _context.Categoria on v.CategId equals ca.CategId
                             //join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                             //join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                             select new VentaDTO
                             {
                                 IdFactura = v.IdFactura,
                                 NumFact = v.NumFact,
                                 FechaHora = v.FechaHora,//
                                 //ClienteDetalle = cl.ClienteNombre,
                                 //ProductoDetalle = pr.ProductoDescrip,
                                 //ModeloDetalle = mo.ModeloDescripción,
                                 //CategDetalle = ca.CategNombre,
                                 //MarcaDetalle = ma.MarcaNombre,
                                 //SucursalDetalle = su.SucursalNombre,
                                 Caja = v.CajaId,
                                 Vendedor = v.VendedorId,//
                                 Precio = v.Precio,//
                                 Estado = v.Estado,//
                             });
                //1
                if (numFact != null || numFact != "0") //&& (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio == 0)
				{
                    respuesta.Cod = "000";
                    respuesta.Data = query.Where(x=> x.NumFact.Equals(numFact)).ToList();
                    //respuesta.Data = await (from v in _context.Ventas
                    //                        join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                    //                        join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                    //                        join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                    //                        join ca in _context.Categoria on v.CategId equals ca.CategId
                    //                        join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                    //                        join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                    //                        where  v.NumFact.Equals(numFact) //&& v.Estado.Equals("A")
                    //                        select new VentaDTO
                    //                        {
                    //                            IdFactura = v.IdFactura,
                    //                            NumFact = v.NumFact,
                    //                            FechaHora = v.FechaHora,//
                    //                            ClienteDetalle = cl.ClienteNombre,
                    //                            ProductoDetalle = pr.ProductoDescrip,
                    //                            ModeloDetalle = mo.ModeloDescripción,
                    //                            CategDetalle = ca.CategNombre,
                    //                            MarcaDetalle = ma.MarcaNombre,
                    //                            SucursalDetalle = su.SucursalNombre,
                    //                            Caja = v.CajaId,
                    //                            Vendedor = v.VendedorId,//
                    //                            Precio = v.Precio,//
                    //                            Estado = v.Estado,//
                    //                        }).ToListAsync();
                    respuesta.Mensaje = "OK";

                    //2
                }else if ((numFact == null || numFact == "0") && (fecha != null || fecha != "0") && vendedor == null && precio == 0)
				{
                    respuesta.Cod = "000";
                    //respuesta.Data = await query.Where(x=> x.NumFact.Equals(numFact)).ToListAsync();
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ca in _context.Categoria on v.CategId equals ca.CategId
                                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                            join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                            where v.Estado.Equals("A") && v.FechaHora.Equals(fecha)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,//
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ca.CategNombre,
                                                MarcaDetalle = ma.MarcaNombre,
                                                SucursalDetalle = su.SucursalNombre,
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,//
                                                Precio = v.Precio,//
                                                Estado = v.Estado,//
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";

                    //3
                }else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && vendedor != null && precio == 0)
				{
                    respuesta.Cod = "000";
                    //respuesta.Data = await query.Where(x=> x.NumFact.Equals(numFact)).ToListAsync();
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ca in _context.Categoria on v.CategId equals ca.CategId
                                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                            join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                            where v.Estado.Equals("A") && v.VendedorId.Equals(vendedor)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,//
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ca.CategNombre,
                                                MarcaDetalle = ma.MarcaNombre,
                                                SucursalDetalle = su.SucursalNombre,
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,//
                                                Precio = v.Precio,//
                                                Estado = v.Estado,//
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                //4
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio != 0)
                {
                    respuesta.Cod = "000";
                    //respuesta.Data = await query.Where(x=> x.NumFact.Equals(numFact)).ToListAsync();
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ca in _context.Categoria on v.CategId equals ca.CategId
                                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                            join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                            where v.Estado.Equals("A") && v.Precio == precio
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,//
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ca.CategNombre,
                                                MarcaDetalle = ma.MarcaNombre,
                                                SucursalDetalle = su.SucursalNombre,
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,//
                                                Precio = v.Precio,//
                                                Estado = v.Estado,//
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                //5
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && (vendedor == null || vendedor == "0") && precio == 0)
                {
                    respuesta.Cod = "000";
                    //respuesta.Data = await query.Where(x=> x.NumFact.Equals(numFact)).ToListAsync();
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ca in _context.Categoria on v.CategId equals ca.CategId
                                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                            join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                            where v.Estado.Equals("A")
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,//
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ca.CategNombre,
                                                MarcaDetalle = ma.MarcaNombre,
                                                SucursalDetalle = su.SucursalNombre,
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,//
                                                Precio = v.Precio,//
                                                Estado = v.Estado,//
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                //6
                else if ((numFact != null || numFact != "0") && (fecha != null || fecha != "0") && (vendedor != null || vendedor != "0") && precio != 0)
                {
                    respuesta.Cod = "000";
                    //respuesta.Data = await query.Where(x=> x.NumFact.Equals(numFact)).ToListAsync();
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ca in _context.Categoria on v.CategId equals ca.CategId
                                            join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                            join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                            where v.NumFact.Equals(numFact) && v.FechaHora.Equals(fecha) && v.VendedorId.Equals(vendedor) && v.Precio == precio && v.Estado.Equals("A")
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,//
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ca.CategNombre,
                                                MarcaDetalle = ma.MarcaNombre,
                                                SucursalDetalle = su.SucursalNombre,
                                                Caja = v.CajaId,
                                                Vendedor = v.VendedorId,//
                                                Precio = v.Precio,//
                                                Estado = v.Estado,//
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
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
