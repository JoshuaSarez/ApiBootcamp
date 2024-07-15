using EjemploEntity.Interface;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ClienteServices : ICliente
    {
		private readonly VentasContext _context; //se hace la inyeccion con la tabla Ventas
        private ControlError Log = new ControlError();

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
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ClienteServices", "GetListaClientes", ex.Message);
            }
			return respuesta;
        }

        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes.OrderByDescending(x=> x.ClienteId).Select(x=> x.ClienteId).FirstOrDefault();
                cliente.ClienteId = query + 1;
                cliente.FechaHoraReg = DateTime.Now;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Data = cliente;
                respuesta.Mensaje = "Se inserto correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ClienteServices", "PostCliente", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Data = cliente;
                respuesta.Mensaje = "Se actualizo correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error comunicase con el departamento de sistemas ";
                Log.LogErrorMethods("ClienteServices", "PostCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
