using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    public static class DominioDiscreto
    {
        public static Dictionary<int, string> Sexo()
        {
            var lista = new Dictionary<int, string>();
            lista.Add(1, "Masculino");
            lista.Add(2, "Feminino");
            return lista;
        }

        public static Dictionary<int, string> EstadoCivil()
        {
            var lista = new Dictionary<int, string>();
            lista.Add(1, "Solteiro(a)");
            lista.Add(2, "Casado(a)");
            lista.Add(3, "Viúvo(a)");
            lista.Add(4, "Separado");
            lista.Add(5, "Divorciado");
            return lista;
        }

        public static Dictionary<int, string> Parentesco()
        {
            var lista = new Dictionary<int, string>();
            lista.Add(1, "Cônjuge");
            lista.Add(2, "Filho(a)");
            lista.Add(3, "Outros");
            return lista;
        }

    }
}
