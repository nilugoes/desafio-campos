using CamposProject.Data;
using CamposProject.Entidades;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CamposProject.Services
{
    public class ClientesService
    {
        private CamposDatabaseContext context;

        public ClientesService(CamposDatabaseContext context)
        {
            this.context = context;
        }

        public void ImportarDados()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.GetAsync("https://camposdealer.dev/Sites/TesteAPI/cliente").GetAwaiter().GetResult();
            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jsonAjustado = json.Replace(@"\", "").TrimStart('"').TrimEnd('"');
            var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(jsonAjustado);
            foreach (var cliente in clientes)
            {
                context.Clientes.Add(cliente);
            }

            context.SaveChanges();
        }
   
    }
}
