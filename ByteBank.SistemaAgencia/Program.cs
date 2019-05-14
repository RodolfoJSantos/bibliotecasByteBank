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
            ContaCorrente conta = new ContaCorrente(123, 12345);


            Console.WriteLine(conta.Numero);

            GerenteDeConta gerente = new GerenteDeConta("2432345254");
            gerente.Autenticar("123");
            

            Console.ReadLine();
        }
    }
}
