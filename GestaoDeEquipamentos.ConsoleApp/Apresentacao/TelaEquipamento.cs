using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar equipamento");
        Console.WriteLine("2 - Editar equipamento");
        Console.WriteLine("3 - Excluir equipamento");
        Console.WriteLine("4 - Visualizar equipamentos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Cadastro de Equipamento");

        Equipamento? novoEquipamento = ObterDadosCadastrais();

        if (novoEquipamento == null)
            return;

        repositorioEquipamento.Cadastrar(novoEquipamento);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoEquipamento.id}\" foi cadastrado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho("Edição de Equipamento");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do equipamento que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Equipamento? novoEquipamento = ObterDadosCadastrais();

        if (novoEquipamento == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível obter os dados do registro.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        bool conseguiuEditar = repositorioEquipamento.Editar(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o equipamento informado.");
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
        ExibirCabecalho("Exclusão de Equipamento");

        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do equipamento que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        bool conseguiuExcluir = repositorioEquipamento.Excluir(idSelecionado);

        if (conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
            Console.WriteLine("---------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontar o registro \"{idSelecionado}\".");
            Console.WriteLine("---------------------------------");
        }

        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Equipamentos");

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
        );

        Equipamento?[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                e.id, e.nome, e.fabricante.nome, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString()
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
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    public Equipamento? ObterDadosCadastrais()
    {
        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -30} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -30} | {3, -15}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja selecionar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante? fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o fabricante informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();

            return null;
        }

        Equipamento novoEquipamento = new Equipamento();

        novoEquipamento.fabricante = fabricanteSelecionado;

        do
        {
            Console.Write("Digite o nome do equipamento: ");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) &&
                novoEquipamento.nome.Length >= 3)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o preço de aquisição do equipamento: ");
        novoEquipamento.precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: ");
        novoEquipamento.dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        return novoEquipamento;
    }
}