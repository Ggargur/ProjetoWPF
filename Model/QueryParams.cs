using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWPF.Model
{
    internal class QueryParams
    {
        private string _startData;
        private string _endData;
        private string _indicator;
    }

    public override string ToString()
    {
        return "/ExpectativaMercadoMensais?%24format=json&%24filter=Data ge '2024-03-05' and Data lt '2024-04-05' and Indicador eq 'IPCA'";
    }
}
