using AddresFront.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

namespace AddresFront.Servicios
{
    public class Servicio : IServicio
    {
        public static string _baseurl;

        public Servicio()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Adquisicion>> Lista()
        {

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var lista = new List<Adquisicion>();

            var response = await cliente.GetAsync("api/Adquisicion/lista");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAdquisicion>(json_respuesta);
                lista = (List<Adquisicion>)resultado.response;
            }

            return lista;
        }

        public async Task<List<Historial>> Historial()
        {

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var lista = new List<Historial>();

            var response = await cliente.GetAsync("api/Adquisicion/historial");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoHistorial>(json_respuesta);
                lista = (List<Historial>)resultado.response;
            }
           
            foreach (var item in lista)
            {
                var listaAdq = new List<Adquisicion>();
                var ob = new Adquisicion();
                listaAdq.Add(JsonConvert.DeserializeObject<Adquisicion>(item.Descripcion));
                item.Adquisiciones = listaAdq;
            }


            return lista;
        }

        public async Task<Adquisicion> Obtener(int id)
        {
            var objeto = new Adquisicion();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Adquisicion/obtener/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                objeto = resultado.response;

            }

            return objeto;
        }

        public async Task<bool> Guardar(Adquisicion objeto) {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Adquisicion/guardar" , content);
            if (response.IsSuccessStatusCode) {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Editar(Adquisicion objeto)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync("api/Adquisicion/editar", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.DeleteAsync($"api/Adquisicion/eliminar/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
