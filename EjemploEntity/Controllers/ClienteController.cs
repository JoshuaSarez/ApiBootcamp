using EjemploEntity.Interface;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
	{
		private readonly ICliente _cliente;
        private ControlError Log = new ControlError();
        public ClienteController (ICliente cliente)
		{
			this._cliente = cliente;
		}

        [HttpGet]
        [Route("GetListaClientes")]
        public async Task<Respuesta> GetListaClientes(int clienteId, string? clienteName, double identificacion)
        {
			var respuesta = new Respuesta();
			try
			{
                respuesta = await _cliente.GetListaClientes(clienteId, clienteName, identificacion);
            }
            catch (Exception ex)
			{
                Log.LogErrorMethods("ClienteController", "GetListaClientes", ex.Message);
            }
			return respuesta;
        }

        //[HttpPost]
        //[Route("PostCliente")]

        //public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        //{
        //    var respuesta = new Respuesta();
        //    try
        //    {
        //        respuesta = await _cliente.PostCliente(cliente);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return respuesta;
        //}
    }
}
