using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_Sami;

namespace Banco_Sami
{
    public class Movimentacao
    {

        public Movimentacao(string tipo, decimal valor)
        {
            Tipo = tipo;
            Valor = valor;
        }

        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
