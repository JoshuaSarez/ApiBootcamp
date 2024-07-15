using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitarios
{
    public class ChuckNorrisChistesMalosYEnIngles
    {
        private ControlError log = new ControlError();

        public async Task<Respuesta> GetChuckNorrisCateg(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var json = await response.Content.ReadAsStringAsync();
                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json); //await response.Content.ReadAsStringAsync();
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ChuckNorrisChistesMalosYEnIngles", "GetChuckNorrisCateg", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetChuckNorrisRandom(string url, string category)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?category={category}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var json = await response.Content.ReadAsStringAsync();
                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisCategDtoList>(json); //await response.Content.ReadAsStringAsync();
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ChuckNorrisChistesMalosYEnIngles", "GetChuckNorrisRandom", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetChuckNorrisQuery(string url, string query)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?query={query}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisCategDto>(json); //await response.Content.ReadAsStringAsync();
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMethods("ChuckNorrisChistesMalosYEnIngles", "GetChuckNorrisQuery", ex.Message);
            }
            return respuesta;
        }
    }
}
