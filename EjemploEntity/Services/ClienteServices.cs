using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ClienteServices : ICliente
    {
		private readonly VentasContext _context; //se hace la inyeccion con la tabla Ventas

		public ClienteServices (VentasContext context)
		{
			this._context = context;
		}

        public async Task<Respuesta> GetListaClientes(int clienteId, string? clienteName, double identificacion)
        {
			var respuesta = new Respuesta();
			try
			{
                var query = _context.Clientes;

				if (clienteId == 0 && clienteName == null && identificacion == 0)
				{
					respuesta.Cod = "000";
					respuesta.Data = await query.Where(x => x.Estado.Equals("A")).ToListAsync();
					respuesta.Mensaje = "OK";
				}else if (clienteId != 0 && clienteName == null && identificacion == 0)
				{
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.ClienteId == clienteId && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }else if (identificacion != 0 && clienteName == null && clienteId == 0)
				{
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Cedula.Equals(identificacion) && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }else if (clienteName != null && clienteId == 0 && identificacion == 0)
				{
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.ClienteNombre.Equals(clienteName) && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }else if (clienteId != 0 && clienteName != null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.ClienteId == clienteId && x.ClienteNombre.Equals(clienteName) && x.Cedula.Equals(identificacion) && x.Estado.Equals("A")).ToListAsync();
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

        //public Task<Respuesta> PostCliente(Cliente cliente)
        //{
        //    var respuesta = new Respuesta();
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return respuesta;
        //}
    }
}
