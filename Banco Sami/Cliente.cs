using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_Sami;

namespace Banco_Sami
{ //regras de negocio
    public class Cliente
    {
        public string Codigo { get; private set; } //Propriedades
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public List<Movimentacao> Movimentacoes { get; set; }


        public Cliente()
        {
            Movimentacoes = new List<Movimentacao>(); //Construtor sem parametros para iniciar lista de movimentações
        }
        //contrutor com paremetros para clientre que chama o contrutor de movimentações
        public Cliente(string nome, string codigo) : this() 
        {
            Nome = nome;
            Codigo = codigo;
        }
        public void RealizarSaque(decimal valor)
        {
            if (Saldo > valor)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo = Saldo - valor;
                AdicionarMovimentacao("SAQUE", valorMenosTaxa);
                Console.WriteLine($"Saque realizado com sucesso. Saldo :{Saldo}");
            }
            else
                Console.WriteLine($"Saldo Insuficiente");
        }
        public void RealizarDeposito(decimal valor)
        {
            if (valor >= 1)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo = Saldo + valor;
                AdicionarMovimentacao("DEPOSITO", valorMenosTaxa);
                Console.WriteLine($"Deposito realizado com sucesso. Saldo :{Saldo}");
            }
            else
                Console.WriteLine($"Valor deve ser maior que R$ 1,00");
        }

        public void AdicionarMovimentacao(string tipo, decimal valor)
        {
            Movimentacoes.Add(new Movimentacao(tipo, DescontarTaxa(valor)));
        }
        public virtual decimal DescontarTaxa(decimal valor)
        {
            return valor;
        }
        















    }


}














