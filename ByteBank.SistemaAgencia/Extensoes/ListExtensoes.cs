using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        public static void Teste()
        {
            List<int> numeros = new List<int>();
            numeros.Add(32);
            numeros.Add(423);

            numeros.AdicionarVarios(32,54,354);
        }

        public static T[] Concatenar<T>(this T[] a, T[] b)
        {
            var resultado = new T[a.Length + b.Length];

            for (int i = 0; i < a.Length; i++)
            {
                resultado[i] = a[i];
            }

            for (int i = 0; i < b.Length; i++)
            {
                resultado[a.Length + i] = b[i];
            }

            return resultado;
        }
    }
}
