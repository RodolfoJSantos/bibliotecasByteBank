﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{

    /// Define uma conta corrente do banco Byte Bank

    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/>, e deve possuir um valor maior que zero.</param>
        /// <param name="numero">>Representa o valor da propriedade <see cref="Numero"/>, e deve possuir um valor maior que zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exeção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            return $"Agência: {Agencia}, Número: {Numero}, Saldo: {Saldo}";
        }

        public override bool Equals(object obj)
        {
            //usamos a conversão AS em vez de cast pois se passar outro tipo por engano
            //(ex: Cliente) irá retornar nulo            
            ContaCorrente outraConta = obj as ContaCorrente;
            if (outraConta == null)
            {
                return false;
            }

            //retorna boleano é o que esperamos para este metodo
            return Agencia == outraConta.Agencia && Numero == outraConta.Numero;
        }

        public int CompareTo(object obj)
        {
            //Renorna negativo quando a instancia precede o obj
            //Retorna 0 quando a instancia e obj forem equivalentes
            //Positivo quando obj for precedente

            //(as) pois caso não converta outraConta fica null e não dá excessão
            //O cast é suficiente para inferir no var
            var outraConta = obj as ContaCorrente;
            if (outraConta == null)
            {
                return -1;
            }

            if (Numero < outraConta.Numero)
            {
                return -1;
            }
            if (Numero == outraConta.Numero)
            {
                return 0;
            }
            return 1;
        }
    }

}
