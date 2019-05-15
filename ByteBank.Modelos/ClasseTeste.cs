using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class ClasseTeste
    {
        public ClasseTeste()
        {
            ModificadoresTeste teste = new ModificadoresTeste();
            teste.MetodoPublico();
            teste.MetodoInterno();
            //teste.MetodoPrivado();

        }
        

    }

    public class ClasseDerivada : ModificadoresTeste
    {
        public ClasseDerivada()
        {
            ModificadoresTeste teste = new ModificadoresTeste();

            MetodoProtegido();
        }
    }

    public class ModificadoresTeste
    {
        public void MetodoPublico()
        {
            //Visível fora da classe "ModificadoresTeste"
        }

        private void MedodoPrivado()
        {
            //Visível somente na classe "ModificadoresTeste"
        }

        protected void MetodoProtegido()
        {
            //Visível na classe "ModificadoresTeste" e derivados
        }

        internal void MetodoInterno()
        {
            //Visível apenas para o projeto "ByteBank.Modelos"
        }

    }
}
