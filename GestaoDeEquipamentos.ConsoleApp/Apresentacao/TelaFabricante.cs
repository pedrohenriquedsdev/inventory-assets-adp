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

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoFabricante.id}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho("Edição de Fabricante");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante? novoFabricante = ObterDadosCadastrais();

        if (novoFabricante == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível obter os dados do registro.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o registro informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Fabricante");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontar o registro informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Fabricantes");

        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -30} | {3, -15} | {4, -10}",
            "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();
        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            int qtdEquipamentos = repositorioFabricante.ContarEquipamentosPorFabricante(f.id, equipamentos);

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -30} | {3, -15} | {4, -10}",
                f.id, f.nome, f.email, f.telefone, qtdEquipamentos
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
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
            Console.Write("Digite o email do fabricante: ");
            novoFabricante.email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.email) &&
                novoFabricante.email.Length >= 5)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o telefone do fabricante: ");
            novoFabricante.telefone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.telefone) &&
                novoFabricante.telefone.Length >= 8)
            {
                break;
            }

        } while (true);

        return novoFabricante;
    }
}