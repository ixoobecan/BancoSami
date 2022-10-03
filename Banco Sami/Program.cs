using System;
using Banco_Sami;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    List<Cliente> Clientes = new();
    ConsultarCliente(); //METODO

    void ConsultarCliente()
{
    Console.WriteLine("OLÁ Bem vindo ao Sami");
    Console.WriteLine("Digite seu codigo");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes)
    {
        if (cli.Codigo == codigo)
        {
            cliente = cli;
        }
    }
    if (cliente == null)
    {
        Console.WriteLine("Este cliente não existe. Deseja cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S")
        {
            Console.WriteLine("Digite seu codigo:");
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome:");
            string nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite PF ou PJ");
            string tipoPessoa = Console.ReadLine();
            if (tipoPessoa == "PF")
            {
                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo); //instanciar pessoa fisica
            }
            else
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo); //instanciar pessoa juridica
        }
        Clientes.Add (cliente);
        ExibirMenu(cliente);
    }
    else
        ConsultarCliente(); 
}   
    void ExibirMenu(Cliente cliente)
    {
        Console.WriteLine($"Ola {cliente.Nome}");
        Console.WriteLine("Digite a opção desejada");
        Console.WriteLine("1 - EXTRATO");
        Console.WriteLine("2 - SAQUE");
        Console.WriteLine("3 - DEPÓSITO");
        string menu = Console.ReadLine();
        switch (menu) 
        {
            case "1":
                ExibirExtrato(cliente);
                break;
            case "2":
                RealizarSaque(cliente);
                break;
            case "3":
                RealizarDeposito(cliente);
                break;
            default:
                Console.WriteLine("Digite uma opção valida.");
                ExibirMenu(cliente);
                break;
        }

    }
    void ExibirExtrato( Cliente cliente)
    {
        Console.WriteLine("________________________EXTRATO________________________");
        foreach (Movimentacao mov in cliente.Movimentacoes)
        {
            Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
        }
        Console.WriteLine("Deseja voltar ao Menu? Digite S ou N");
        string exibirMenu = Console.ReadLine();
    if (exibirMenu == "S")
    
        ExibirMenu(cliente);
    
    else
    
        Console.WriteLine("Consultar outro cliente? Digite S ou N");
        string consultarCliente = Console.ReadLine();
        if (consultarCliente == "S")
            ConsultarCliente();
    }  
    void RealizarSaque( Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar:");
    string valor = Console.ReadLine();
    cliente.RealizarSaque(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja fazer outra operação? Digite S ou N");
    string realizarOutraOperacao = Console.ReadLine();
    if (realizarOutraOperacao == "S")
    
        ExibirMenu(cliente);
    
    else 
    
        Console.WriteLine("Volte Sempre!");
    

}
    void RealizarDeposito(Cliente cliente) 
{
    Console.WriteLine("Qual valor deseja depositar?");
    string valor = Console.ReadLine();
    cliente.RealizarDeposito(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar alguma outra transação? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else
        Console.WriteLine("Volte Sempre!");


}


     

        
    
    






