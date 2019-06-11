using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using ByteBank.SistemaAgencia.Extensoes;
using ByteBank.SistemaAgencia.Comparadores;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(123,12345),
                new ContaCorrente(643,11111),
                new ContaCorrente(234,22222),
                new ContaCorrente(123,99999),
                new ContaCorrente(809,44444),
                new ContaCorrente(723,51324),
                
            };

            //contas.Sort();
            contas.Sort(new ComparadorContaCorrentePorAgencia());
            foreach (var conta in contas)
            {
                Console.WriteLine($"Agencia: {conta.Agencia}, Número: {conta.Numero}");
            }

            Console.ReadLine();
        }

        static void TestaListaObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.AdicionarVarios(16, 23, 60);
            listaDeIdades.Adicionar("texto teste");

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>();
            nomes.Add("Rodolfo");
            nomes.Add("José");
            nomes.Add("Heitor");
            nomes.Add("Clarindo");
            nomes.AdicionarVarios("Ana", "Jéssica", "karine");

            nomes.Sort();
            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }

            var nome = new List<string>
            {
                "Pedro",
                "Anabel",
                "Zumira"
            };
            nome.Sort();
            foreach (var item in nome)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

            var idades = new List<int>();
            idades.Add(18);
            idades.Add(3);
            idades.Add(90);
            idades.Add(25);
            idades.Add(7);

            idades.AdicionarVarios(54, 12, 63, 88);

            idades.Sort();
            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
            Console.ReadLine();
        }

        static int SomaVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        public static void SomarNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length -1; i+=2)
            {
                int n1 = numeros[i];
                int n2 = numeros[i + 1];
                int soma = n1 + n2;
                Console.WriteLine($"soma do {i}º com o {i+1}° número = " +soma);
            }
        }

        public static void TestandoArrayConta()
        {
            ContaCorrente[] contas = new ContaCorrente[]
           {
                new ContaCorrente(123, 4565),
                new ContaCorrente(333, 2333),
                new ContaCorrente(436, 0976),
                new ContaCorrente(234, 4444),
                new ContaCorrente(234, 4444)
           };

            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta: {i}, Número: {contaAtual.Numero}");
            }

        }

        public static void TestandoString()
        {

            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            ContaCorrente conta = new ContaCorrente(123, 1234);

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadLine();

            Console.ReadLine();
            //Ligue no número 4444-2222
            //olá meu nome é Fulano, telefone 4444 3333


            //string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padrao = "[0-9]4[-][0-9][0-9][0-9][0-9]";
            //string padrao = "[0-9]{4,5}[-][0-9]{4}";
            //string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}[-]?[0-9]{4}";
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 944844546";

            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value);
            Console.ReadLine();

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
