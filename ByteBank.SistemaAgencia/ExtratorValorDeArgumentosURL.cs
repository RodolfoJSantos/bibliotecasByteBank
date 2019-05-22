using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
<<<<<<< HEAD

        private readonly string _argumentos;

        public string URL { get; }

            public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }

            URL = url;
=======
        //Guarda em um campo privado a lista de argumentos
        private readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Argumento url não pode ser nulo ou vazio. ", nameof(url));
            }

            URL = url;

>>>>>>> no work
            int indexInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indexInterrogacao + 1);
        }

        public string GetValor(string nomeParametro)
        {
<<<<<<< HEAD
            //tudo em maiusculo para resolver o case sensitive do indexOf
            nomeParametro = nomeParametro.ToUpper();
            string argumentosCaixaAlta = _argumentos.ToUpper();

            string termo = nomeParametro + "=";
            int indicadorParametro = argumentosCaixaAlta.IndexOf(termo);

            //mantem o _arumentos para exibir na tela em minusculo
            string resultado = _argumentos.Substring(indicadorParametro + termo.Length);
            int indexEComercial = resultado.IndexOf('&');

=======
            string termo = nomeParametro + "=";
            int indiceParametro = _argumentos.IndexOf(termo);

            //pega o nome do argumento
            string resultado = _argumentos.Substring(indiceParametro + termo.Length);
            //exclui o restante
            int indexEComercial = resultado.IndexOf('&');

            //se não existir '&'
>>>>>>> no work
            if (indexEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indexEComercial);
        }
<<<<<<< HEAD

        
=======
>>>>>>> no work
    }
}
