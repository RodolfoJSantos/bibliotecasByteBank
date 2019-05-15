using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dataPagamento = new DateTime(2019, 10, 15);
            DateTime dataCorrente = DateTime.Now;

            Console.WriteLine(dataCorrente);
            Console.WriteLine(dataPagamento);

            TimeSpan diferenca = dataPagamento - dataCorrente;
            Console.WriteLine("Vencimento em: " + diferenca);


            Console.ReadLine();
        }
    }
}
