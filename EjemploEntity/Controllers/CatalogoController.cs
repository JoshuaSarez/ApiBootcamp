﻿using EjemploEntity.Interface;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
		private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria()
        {
			var respuesta = new Respuesta();
			try
			{
				respuesta = await _catalogo.GetCategoria();
			}
			catch (Exception ex)
			{
                Log.LogErrorMethods("CatalogoController", "GetCategoria", ex.Message);
            }
			return respuesta;
        }

        [HttpGet]
        [Route("GetMarca")]
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetMarca();
            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "GetMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetModelo")]
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModelo();
            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetSucursal")]
        public async Task<Respuesta> GetSucursal()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetSucursal();
            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCiudad();
            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "GetCiudad", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCaja")]
        public async Task<Respuesta> GetCaja()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCaja();
            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "GetCaja", ex.Message);
            }
            return respuesta;
        }
        
        //POST
        //No olvidar el FromBody xD
        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody]Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMarca")]
        public async Task<Respuesta> PostMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostMarca(marca);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostModelo")]
        public async Task<Respuesta> PostModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModelo(modelo);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostSucursal")]
        public async Task<Respuesta> PostSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostSucursal(sucursal);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCiudad")]
        public async Task<Respuesta> PostCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCiudad(ciudad);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCaja")]
        public async Task<Respuesta> PostCaja([FromBody] Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCaja(caja);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PostCaja", ex.Message);
            }
            return respuesta;
        }

        //PUT
        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMarca")]
        public async Task<Respuesta> PutMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutMarca(marca);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModelo(modelo);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutSucursal")]
        public async Task<Respuesta> PutSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutSucursal(sucursal);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCiudad")]
        public async Task<Respuesta> PutCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCiudad(ciudad);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutCiudad", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCaja")]
        public async Task<Respuesta> PutCaja([FromBody] Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCaja(caja);

            }
            catch (Exception ex)
            {
                Log.LogErrorMethods("CatalogoController", "PutCaja", ex.Message);
            }
            return respuesta;
        }

        //DELETE
        //[HttpPut]
        //[Route("DeleteCategoria")]
        //public async Task<Respuesta> DeleteCategoria([FromBody] int categoriaId)
        //{
        //    var respuesta = new Respuesta();
        //    try
        //    {
        //        respuesta = await _catalogo.DeleteCategoria(categoriaId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.LogErrorMethods("CatalogoController", "DeleteCategoria", ex.Message);
        //    }
        //    return respuesta;
        //}

    }
}
