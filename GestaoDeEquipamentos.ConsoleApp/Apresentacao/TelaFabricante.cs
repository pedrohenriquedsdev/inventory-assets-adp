using System.Globalization;
using System.Net.Mail;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;
    public RepositorioEquipamento repositorioEquipamento;

    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar fabricante");
        Console.WriteLine("2 - Editar fabricante");
        Console.WriteLine("3 - Excluir fabricante");
        Console.WriteLine("4 - Visualizar fabricantes");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Cadastro de Fabricante");

        Fabricante novoFabricante = ObterDadosCadastrais();

        repositorioFabricante.Cadastrar(novoFabricante);

        ExibirMensagem($"O registro \"{novoFabricante.id}\" foi cadastrado com sucesso.");
    }

    public void Editar()
    {
        ExibirCabecalho("Edição de Fabricante");

        VisualizarTodos(exibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante novoFabricante = ObterDadosCadastrais();

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            ExibirMensagem($"Não foi possível encontrar o equipamento informado.");
            return;
        }

        ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso.");
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Fabricante");

        VisualizarTodos(exibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool contemEquipamentoVinculado = repositorioEquipamento.ExisteEquipamentoDoFabricante(idSelecionado);

        if (contemEquipamentoVinculado)
        {
            ExibirMensagem($"Não é possível excluir um fabricante com equipamentos vinculados.");
            return;
        }

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem($"Não foi possível encontrar o fabricante informado.");
            return;
        }

        ExibirMensagem($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
    }

    public void VisualizarTodos(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho("Visualização de Fabricantes");

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -25} | {3, -22} | {4, -20}",
            "Id", "Nome", "Email", "Telefone", "Qtd. de Equipamentos"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();
        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            int quantidadeEquipamentos = 0;

            for (int j = 0; j < equipamentos.Length; j++)
            {
                Equipamento? e = equipamentos[j];

                if (e == null)
                    continue;

                if (e.fabricante == f)
                    quantidadeEquipamentos++;
            }

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -25} | {3, -22} | {4, -20}",
                f.id, f.nome, f.email, f.telefone, quantidadeEquipamentos
            );
        }

        if (exibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    public Fabricante ObterDadosCadastrais()
    {
        Fabricante novoFabricante = new Fabricante();

        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) &&
                novoFabricante.nome.Length >= 3)
            {
                break;
            }
        } while (true);

        do
        {
            Console.Write("Digite o email do equipamento: ");
            novoFabricante.email = Console.ReadLine();

            if (MailAddress.TryCreate(novoFabricante.email, out _))
            {
                break;
            }
        } while (true);

        do
        {
            Console.Write("Digite o telefone do fabricante: ");
            novoFabricante.telefone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.telefone))
            {
                bool existeLetraOuSimbolo = false;

                for (int i = 0; i < novoFabricante.telefone.Length; i++)
                {
                    char caractereAtual = novoFabricante.telefone[i];

                    if (!char.IsDigit(caractereAtual))
                        existeLetraOuSimbolo = true;
                }

                if (!existeLetraOuSimbolo)
                    break;
            }
        } while (true);

        return novoFabricante;
    }

    public void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine(mensagem);
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}