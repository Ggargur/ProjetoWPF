using ProjetoWPF.Model;

namespace ProjetoWPF.API
{
    /// <summary>
    /// Faz a comunicação da View com a API, além de manter às datas limite e o indicador buscado.
    /// </summary>
    internal class DataHandler
    {
        /// <summary>
        /// Singleton. Ou seja, implementação única dessa classe.
        /// </summary>
        public static DataHandler Instance
        {
            get => _instance ??= new DataHandler();
        }
        private static DataHandler? _instance;

        // Todos 3 dados buscados são verificados, se são iguais para evitar de fazer buscas desnecessárias
        public string? StartDate
        {
            get => _startDate; set
            {
                if(_startDate == value) return;
                _startDate = value;
                SendQuery();
            }
        }
        public string? EndDate
        {
            get => _endDate; set
            {
                if(_endDate == value) return;
                _endDate = value;
                SendQuery();
            }
        }
        public string? Indicator
        {
            get => _indicator; set
            {
                if(_indicator == value) return;
                _indicator = value;
                SendQuery();
            }
        }


        private string? _startDate;
        private string? _endDate;
        private string? _indicator;

        /// <summary>
        /// Evento que é chamado quando valores novos foram buscados.
        /// </summary>
        public event Action<ExpectativaMensalMercado[]>? OnValuesGot;
        /// <summary>
        /// Valores de expectativa mensal mais atuais buscados.
        /// </summary>
        public ExpectativaMensalMercado[]? Values { get; private set; }

        /// <summary>
        /// Envia uma nova query http, caso todos os valores de filtro não forem nulos.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        private async void SendQuery()
        {
            if (_startDate == null || _endDate == null || _indicator == null) return;

            var response = await APIHandler.GetRequest(new QueryParams(_startDate, _endDate, _indicator)) ?? throw new NullReferenceException();
            Values = response.Value;
            OnValuesGot?.Invoke(Values);
        }

        // Construtor privado por tratar-se de uma singleton.
        private DataHandler()
        {

        }
    }
}
