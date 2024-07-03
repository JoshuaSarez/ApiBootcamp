using EjemploEntity.Interface;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : Controller
    {
        private readonly IVentas _ventas;

        public VentaController(IVentas ventas)
        {
            this._ventas = ventas;
        }

        [HttpGet]
        [Route("GetVentaCliente")]
        public async Task<Respuesta> GetVentaCliente(string? numFact, string? fecha, string? vendedor, double? precio)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.GetVentaCliente(numFact, fecha, vendedor, precio);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

    }
}
