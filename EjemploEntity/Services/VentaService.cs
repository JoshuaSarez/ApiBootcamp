﻿using EjemploEntity.DTOs;
using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjemploEntity.Utilitarios;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace EjemploEntity.Services
{
    public class VentaService : IVentas
    {
		private readonly VentasContext _context;
        private ControlError Log = new ControlError();

		public VentaService (VentasContext context)
		{
			this._context = context;
		}


        public async Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, int vendedor, double precio, int clienteId)
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
                                                    vendedorId = ve.VendedorId,//para poder filtrar con vendedor se necesita con id tmb
                                                   Vendedor = ve.VendedorDescripcion,
                                                    Precio = v.Precio,//
                                                    Unidades = v.Unidades,
                                                    Estado = v.Estado,//
                                                }).AsQueryable();
                respuesta.Cod = "000";
                //1
                if ((numFact != null || numFact != "0") && (fecha != null || fecha != "0") && vendedor !=0 && precio != 0 && clienteId != 0)
                {
                    query = query.Where(x => x.NumFact.Equals(numFact) && x.FechaHora.Equals(fecha) && x.vendedorId == vendedor && x.Precio == precio);// && x.Estado == 1);
                }
                //2
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && vendedor == 0 && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.Estado == 1);
                }
                //3
                else if ((numFact != null || numFact != "0") && (fecha == null || fecha == "0") && vendedor == 0 && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.NumFact.Equals(numFact));// && x.Estado == 1);
                }
                //4
                else if ((numFact == null || numFact == "0") && (fecha != null || fecha != "0") && vendedor == 0 && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.FechaHora.ToString().Equals(fecha));// && x.Estado == 1);
                }
                //5
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && vendedor != 0 && precio == 0 && clienteId == 0)
                {
                    query = query.Where(x => x.vendedorId == vendedor);// && x.Estado == 1);
                }
                //6
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && vendedor == 0 && precio != 0 && clienteId == 0)
                {
                    query = query.Where(x => x.Precio == precio);// && x.Estado == 1);
                }
                //7
                else if ((numFact == null || numFact == "0") && (fecha == null || fecha == "0") && vendedor == 0 && precio == 0 && clienteId != 0)
                {
                    query = query.Where(x => x.ClienteId == clienteId);
                }
                

                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }

			catch (Exception ex)
			{
                respuesta.Cod = "999";
                Log.LogErrorMethods("VentaService", "GetVentaCliente", ex.Message);
                
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
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("VentaService", "PostVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("VentaService", "PutVenta", ex.Message);
            }
            return respuesta;
        }
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
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("VentaService", "GetVenta", ex.Message);
            }
            return respuesta;
        }
    }
}
