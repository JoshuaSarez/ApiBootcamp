using EjemploEntity.Interface;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class CatalogoService : ICatalogo
    {
        //INYECCION DE DEPENDENCIA
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

        public CatalogoService(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Categoria.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Marcas.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetMarca", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Modelos.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Sucursals.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCiudad()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Ciudads.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCaja()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Cajas.ToListAsync();
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "GetCaja", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Categoria.OrderByDescending(x=> x.CategId).Select(x=> x.CategId).FirstOrDefault();
                categoria.CategId = query + 1;
                categoria.FechaHoraReg = DateTime.Now;

                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Data = categoria;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostMarca(Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Marcas.OrderByDescending(x => x.MarcaId).Select(x=> x.MarcaId).FirstOrDefault();
                marca.MarcaId = query + 1;
                marca.FechaHoraReg = DateTime.Now;

                _context.Marcas.Add(marca);//se agrega
                await _context.SaveChangesAsync();//commit

                respuesta.Cod = "000";
                respuesta.Data = marca;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostMarca", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostModelo(Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Modelos.OrderByDescending(x => x.ModeloId).Select(x => x.ModeloId).FirstOrDefault();
                modelo.ModeloId = query + 1;
                modelo.FechaHoraReg = DateTime.Now;

                _context.Modelos.Add(modelo);//se agrega
                await _context.SaveChangesAsync();//commit

                respuesta.Cod = "000";
                respuesta.Data = modelo;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Sucursals.OrderByDescending(x => x.SucursalId).Select(x => x.SucursalId).FirstOrDefault();
                sucursal.SucursalId = query + 1;
                sucursal.FechaHoraReg = DateTime.Now;

                _context.Sucursals.Add(sucursal);//se agrega
                await _context.SaveChangesAsync();//commit

                respuesta.Cod = "000";
                respuesta.Data = sucursal;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCiudad(Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ciudads.OrderByDescending(x => x.CiudadId).Select(x => x.CiudadId).FirstOrDefault();
                ciudad.CiudadId = query + 1;
                ciudad.FechaHoraReg = DateTime.Now;

                _context.Ciudads.Add(ciudad);//se agrega
                await _context.SaveChangesAsync();//commit

                respuesta.Cod = "000";
                respuesta.Data = ciudad;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostCaja(Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Cajas.OrderByDescending(x => x.CajaId).Select(x => x.CajaId).FirstOrDefault();
                caja.CajaId = query + 1;
                //caja.FechaHoraReg = DateTime.Now;

                _context.Cajas.Add(caja);//se agrega
                await _context.SaveChangesAsync();//commit

                respuesta.Cod = "000";
                respuesta.Data = caja;
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("CatalogoService", "PostCaja", ex.Message);
            }
            return respuesta;
        }
    }
}
