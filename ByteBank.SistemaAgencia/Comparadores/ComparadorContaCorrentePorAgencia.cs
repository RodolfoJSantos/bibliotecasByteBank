using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            //caso de referencia nula, já que x e y apontam para mesma referencia
            if (x == y)
            {
                return -1;
            }
            if (x.Agencia < y.Agencia)
            {
                return -1;
            }
            if (x.Agencia == y.Agencia)
            {
                return 0;
            }
            return 1;

            //Nossas comparaçoes são equivalentes ao que já existe no tipo INT
            //x.Agencia.CompareTo(y.Agencia);
        }
    }
}
