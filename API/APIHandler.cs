using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using ProjetoWPF.Model;


namespace ProjetoWPF.API
{
    /// <summary>
    /// Classe estática responsável pelas chamadas http à API.
    /// </summary>
    public static class APIHandler
    {
        private static readonly string queryURL = "https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/";

        private static readonly HttpClient client = new();

        /// <summary>
        /// Envia uma request à API usando os parâmetros data inicial, data final e indicador
        /// encapsulados pela classe QueryParams.
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public static async Task<ODataResponse<ExpectativaMensalMercado>?> GetRequest(QueryParams queryParams)
        {
            HttpResponseMessage message;
            try
            {
                message = await client.GetAsync(queryURL + queryParams.ToString());
                message.EnsureSuccessStatusCode();
                return await message.Content.ReadFromJsonAsync<ODataResponse<ExpectativaMensalMercado>>(); ;
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar com a API", "Erro na requisição", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }
    }
}
