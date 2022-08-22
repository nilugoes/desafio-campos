using CamposProject.Data;
using CamposProject.Entidades;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CamposProject.Services
{
    public class VendasService
    {
        private CamposDatabaseContext context;

        public VendasService(CamposDatabaseContext context)
        {
            this.context = context;
        }

        public void ImportarDados()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = httpClient.GetAsync("https://camposdealer.dev/Sites/TesteAPI/venda").GetAwaiter().GetResult();
            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var jsonAjustado = json.Replace(@"\", "").TrimStart('"').TrimEnd('"');
            var vendas = System.Text.Json.JsonSerializer.Deserialize<List<Venda>>(jsonAjustado);
            foreach (var venda in vendas)
            {
                venda.VlrTotalVenda = venda.VlrUnitarioVenda * venda.QtdVenda;
                context.Vendas.Add(venda);
            }

            context.SaveChanges();
        }
    }
}
