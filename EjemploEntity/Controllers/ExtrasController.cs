using Azure;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {
        private ControlError log = new ControlError();
        private PokeApi pokeApi = new PokeApi();
        private ChuckNorrisChistesMalosYEnIngles chuckNCategApi = new ChuckNorrisChistesMalosYEnIngles();

        private readonly IConfiguration _configuration;
        
        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlPokeApi").Value!;
               
                respuesta = await pokeApi.GetPokeApi(url);
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisCateg")]
        public async Task<Respuesta> GetChuckNorrisCateg()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlChuckNorrisCateg").Value!;

                respuesta = await chuckNCategApi.GetChuckNorrisCateg(url);
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ExtrasController", "GetChuckNorrisCateg", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisRandom")]
        public async Task<Respuesta> GetChuckNorrisRandom(string category)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlChuckNorrisRandom").Value!;

                respuesta = await chuckNCategApi.GetChuckNorrisRandom(url, category);
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ExtrasController", "GetChuckNorrisRandom", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisQuery")]
        public async Task<Respuesta> GetChuckNorrisQuery(string query)
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlChuckNorrisQuery").Value!;

                respuesta = await chuckNCategApi.GetChuckNorrisQuery(url, query);
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ExtrasController", "GetChuckNorrisQuery", ex.Message);
            }
            return respuesta;
        }
    }
}
