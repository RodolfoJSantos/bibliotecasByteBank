using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {


            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=dolar&moedaDestino=real&valor=1500";
            ExtratorValorDeArgumentosURL extratorArgumentos = new ExtratorValorDeArgumentosURL(urlParametros);

            string valor0 = extratorArgumentos.GetValor("moedaOrigem");
            Console.WriteLine("Valor do moedaOrigem: " + valor0);

            string valor1 = extratorArgumentos.GetValor("moedaDestino");
            Console.WriteLine("Valor do moedaDestino: " + valor1);

            string valor2 = extratorArgumentos.GetValor("VALOR");
            Console.WriteLine("Parametro valor: " + valor2);
            Console.ReadLine();


            //Testando Replace
            string palavraOrigem = "PALAVRA";
            string termoBusca = "pa";
            Console.WriteLine(termoBusca.ToUpper());
            Console.WriteLine(palavraOrigem.ToLower());

            termoBusca = termoBusca.Replace('p', 'P');
            Console.WriteLine(termoBusca);
            termoBusca = termoBusca.Replace('a', 'A');
            Console.WriteLine(termoBusca);

            Console.WriteLine(palavraOrigem.IndexOf(termoBusca));
            Console.ReadLine();


            string palavra = "moedaOrigem=real&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino";

            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);

            Console.WriteLine("Tamanho da string " + palavra.Length);
            Console.WriteLine(palavra.Substring(indice));
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length + 1));
            Console.ReadLine();


            string textoVazio = "";
            string textoNulo = null;
            string texto = "dsfgsdf";

            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));


            //Teste Remoção

            string testeRemocao = "primeiraParte&12345";

            int indiceEComercial = testeRemocao.IndexOf('&');

            Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));

            Console.ReadLine();

            string url = "pagina?argumentos";
            int indexInterrogacao = url.IndexOf('?');
            string argumentos = url.Substring(indexInterrogacao + 1);



            Console.WriteLine(argumentos);

            Console.ReadLine();
        }
    }
}
