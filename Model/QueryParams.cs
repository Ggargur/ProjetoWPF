using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWPF.Model
{
    public class QueryParams
    {
        private string _startDate;
        private string _endDate;
        private string _indicator;

        public QueryParams(string startData, string endData, string indicator)
        {
            _startDate = startData;
            _endDate = endData;
            _indicator = indicator;
        }

        public override string ToString()
        {
            return $"/ExpectativaMercadoMensais?%24format=application/json;odata.metadata=none&%24filter=Data ge '{_startDate}' and Data lt '{_endDate}' and Indicador eq '{_indicator}'";
        }
    }
}
