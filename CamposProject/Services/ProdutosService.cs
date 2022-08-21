using CamposProject.Data;
using CamposProject.Entidades;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CamposProject.Services
{
    public class ProdutosService
    {
        private CamposDatabaseContext context;

        public ProdutosService(CamposDatabaseContext context)
        {
            this.context = context;
        }

        public void ImportarDados()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.GetAsync("https://camposdealer.dev/Sites/TesteAPI/produto").GetAwaiter().GetResult();
            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jsonAjustado = json.Replace(@"\", "").TrimStart('"').TrimEnd('"');
            var produtos = System.Text.Json.JsonSerializer.Deserialize<List<Produto>>(jsonAjustado);
            foreach (var produto in produtos)
            {
                context.Produtos.Add(produto);
            }

            context.SaveChanges();
        }
    }
}
