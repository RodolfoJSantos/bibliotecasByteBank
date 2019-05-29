using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrente(int capacidadeInicial =5)
        {
            _itens = new ContaCorrente[5];
            _proximaPosicao = 0;
        }

        public void Exibe()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];
                Console.WriteLine($"Conta númerol: {conta.Numero} - agencia: {conta.Agencia}");
            }
            
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificaCapacidade(_proximaPosicao + 1);
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++; 
        }

        public void adicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;//-1 pois não é permitido no array, será usado depois

            //próxima posição pois só precisamos das posições com valores 
            for (int i = 0; i < _proximaPosicao; i++)
            {
                //simplifica o if
                ContaCorrente itemAtual = _itens[i];
                //equals sobrescrito para comparar agencia e numero
                if (item.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }
            //começa em indiceItem pois é a conta no indice encontrado no for acima
            //será usada para ser removida, vai até a _proximaPosicao = ref nula
            for (int i = indiceItem; i < _proximaPosicao -1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        private void VerificaCapacidade(int tamanhoCapacidade)
        {
            if (_itens.Length > tamanhoCapacidade)
            {
                return;
            }
            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoCapacidade)
            {
                novoTamanho = tamanhoCapacidade;
            }

            Console.WriteLine("Aumentando Capacidade da Lista");
            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];
            for (int i = 0; i < _itens.Length; i++)
            {
                Console.WriteLine('.');
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        }

        public ContaCorrente this[int indice]
        {
            get
            {
               return GetItemNoIndice(indice);
            }
     
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentException(nameof(indice));
            }

            return _itens[indice];
        }
    }
}
