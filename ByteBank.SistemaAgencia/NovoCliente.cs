using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class NovoCliente : Funcionario
    {
        //Construtor obrigatório pasando os parametros para a base
        public NovoCliente(double salario, string cpf)
            :base(salario, cpf)
        {

        }
        public override void AumentarSalario()
        {
            //implementado
        }

        protected override double GetBonificacao()
        {
            return 0;
        }
    }
}
