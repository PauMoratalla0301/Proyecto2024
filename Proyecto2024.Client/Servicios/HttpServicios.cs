
using System.Text.Json;

namespace Proyecto2024.Client.Servicios
{
    public class HttpServicios
    {
        private readonly HttpClient http;

        public HttpServicios(HttpClient http)
        {
            this.http = http;
        }


        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var reponse = await http.GetAsync(url);
            if (reponse.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(reponse);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, reponse);
            }
        }

        private async Task<T> DesSerializar<T>(HttpResponseMessage reponse)
        {
            var respuestaStr = await reponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaStr,

                  new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true }); 
        }
    }
}
