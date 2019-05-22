using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {

        private readonly string _argumentos;

        public string URL { get; }

            public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }

            URL = url;
            int indexInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indexInterrogacao + 1);
        }

        public string GetValor(string nomeParametro)
        {
            //tudo em maiusculo para resolver o case sensitive do indexOf
            nomeParametro = nomeParametro.ToUpper();
            string argumentosCaixaAlta = _argumentos.ToUpper();

            string termo = nomeParametro + "=";
            int indicadorParametro = argumentosCaixaAlta.IndexOf(termo);

            //mantem o _arumentos para exibir na tela em minusculo
            string resultado = _argumentos.Substring(indicadorParametro + termo.Length);
            int indexEComercial = resultado.IndexOf('&');

            if (indexEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indexEComercial);
        }

        
    }
}
