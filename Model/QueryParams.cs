namespace ProjetoWPF.Model
{
    /// <summary>
    /// Representa os parâmetros enviados para a query http.
    /// </summary>
    public class QueryParams
    {
        private readonly string _startDate;
        private readonly string _endDate;
        private readonly string _indicator;

        public QueryParams(string startData, string endData, string indicator)
        {
            _startDate = startData;
            _endDate = endData;
            _indicator = indicator;
        }
        // Sobrescrevendo a definição de ToString para ultiliza-lo como trascrição da classe quando for
        // concatena-lo à URL da API. 
        public override string ToString()
        {
            string value = $"filter=Data ge '{_startDate}' and Data lt '{_endDate}' and Indicador eq '{_indicator}'";
            if (_indicator == "Selic")
                return "ExpectativasMercadoSelic?%24format=application/json;odata.metadata=none&%24" + value;
            return "ExpectativaMercadoMensais?%24format=application/json;odata.metadata=none&%24" + value;
        }
    }
}
