using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWPF.Model
{
    internal class ExpectativaMensalMercado
    {
        private string _indicador;
        private string _data;
        private string _media;
        private string _mediana;
        private string _desvioPadrao;
        private string _minimo;
        private string _maximo;
        private string _numeroRespondentes;
        private string _baseCalculo;

        public ExpectativaMensalMercado(string indicador, string data, string media, string mediana,
            string desvioPadrao, string minimo, string maximo, string numeroRespondentes, string baseCalculo)
        {
            _indicador = indicador;
            _data = data;
            _media = media;
            _mediana = mediana;
            _desvioPadrao = desvioPadrao;
            _minimo = minimo;
            _maximo = maximo;
            _numeroRespondentes = numeroRespondentes;
            _baseCalculo = baseCalculo;
        }
    }
}
