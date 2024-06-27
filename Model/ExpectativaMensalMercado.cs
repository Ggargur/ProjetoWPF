using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWPF.Model
{
    public class ExpectativaMensalMercado
    {
        private string _indicador;
        private string _data;
        private string _dataReferencia;
        private float _media;
        private float _mediana;
        private float _desvioPadrao;
        private float _minimo;
        private float _maximo;
        private int _numeroRespondentes;
        private int _baseCalculo;

        public ExpectativaMensalMercado(string indicador, string data, float media, float mediana,
            float desvioPadrao, float minimo, float maximo, int numeroRespondentes, int baseCalculo, string dataReferencia)
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
            _dataReferencia = dataReferencia;
        }

        public string Indicador { get => _indicador; set => _indicador = value; }
        public string Data { get => _data; set => _data = value; }
        public float Media { get => _media; set => _media = value; }
        public float Mediana { get => _mediana; set => _mediana = value; }
        public float DesvioPadrao { get => _desvioPadrao; set => _desvioPadrao = value; }
        public float Minimo { get => _minimo; set => _minimo = value; }
        public float Maximo { get => _maximo; set => _maximo = value; }
        public int NumeroRespondentes { get => _numeroRespondentes; set => _numeroRespondentes = value; }
        public int BaseCalculo { get => _baseCalculo; set => _baseCalculo = value; }
        public string DataReferencia { get => _dataReferencia; set => _dataReferencia = value; }
    }
}
