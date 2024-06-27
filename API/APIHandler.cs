using ProjetoWPF.Model;
using System.Net.Http;
using System.Net.Http.Json;


namespace ProjetoWPF.API
{
    public static class APIHandler
    {
        private static readonly string queryURL = "https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata";
        private static readonly HttpClient client = new();

        public static async Task<ODataResponse<ExpectativaMensalMercado>?> GetRequest(QueryParams queryParams)
        {
            HttpResponseMessage message = await client.GetAsync(queryURL + queryParams.ToString());
            message.EnsureSuccessStatusCode();
            return await message.Content.ReadFromJsonAsync<ODataResponse<ExpectativaMensalMercado>>();
        }
    }
}
