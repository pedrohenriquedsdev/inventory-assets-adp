using System.Linq.Expressions;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;


public class TelaChamado
{
    public RepositorioChamado repositorioChamado; //atributos
    public RepositorioEquipamento repositorioEquipamento; //atributos

    public string? ObterEscolhaMenuPrinciapl()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar chamado");
        Console.WriteLine("2 - Editar chamado");
        Console.WriteLine("3 - Excluir chamado");
        Console.WriteLine("4 - Visualizar chamados");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }
    public void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de Chamado");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
                               "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                               "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO"
                           );

        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos(); //passamos a referência do objeto

        for (int i = 0; i < equipamentos.Length; i++) //percorremos todos os indíces de 0 a 99
        {
            Equipamento? e = equipamentos[i]; //referencia o valor de cada índice

            if (e == null) //null guard
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite o ID do equipamento que deseja selecionar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Equipamento? equipamentoSelecionado = repositorioEquipamento.SelecionarPorID(idSelecionado);

        if (equipamentoSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possível encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return;
        }

        Chamado novoChamado = new Chamado(); //A partir do momento 

        novoChamado.equipamento = equipamentoSelecionado;

        do
        {
            Console.WriteLine("Digite o título do chamado: ");
            novoChamado.titulo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoChamado.titulo) && novoChamado.titulo.Length >= 3)
                break;

        } while (true);

        Console.WriteLine("Digite a descrição do chamado: ");
        novoChamado.descricao = Console.ReadLine();

        novoChamado.dataAbertura = DateTime.Now;

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro {novoChamado.id} foi cadastrado com sucesso");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public void Editar()
    {

    }
    public void Excluir()
    {

    }
    public void VisualizarTodos()
    {

    }

}
