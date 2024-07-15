using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitarios
{
    public class PokeApi
    {
		private ControlError log = new ControlError();
        public async Task<Respuesta> GetPokeApi(string url) //Método
        {
			var respuesta = new Respuesta();
			try
			{
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<PokeApiDto>(json); //await response.Content.ReadAsStringAsync();
                respuesta.Mensaje = "Se consumio correctamente";

                //Console.WriteLine();

            }
            catch (Exception ex)
			{
				log.LogErrorMethods("PokeApi", "GetPokeApi", ex.Message);
			}
			return respuesta;
        }
    }
}
