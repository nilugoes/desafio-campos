using CamposProject.Data;
using CamposProject.Services;

namespace CamposProject
{
    public class DbInitializer
    {
        internal static void Initialize(CamposDatabaseContext context)
        {
            ClientesService clientesService = new ClientesService(context);
            clientesService.ImportarDados();

            ProdutosService produtosService = new ProdutosService(context);
            produtosService.ImportarDados();

            VendasService vendasService = new VendasService(context);
            vendasService.ImportarDados();

        }
    }
}
