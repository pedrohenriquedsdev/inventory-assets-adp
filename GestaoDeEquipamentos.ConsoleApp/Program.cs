namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Equipamento?[] equipamentos = new Equipamento[100];

        while (true)
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

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Cadastro de Equipamento");
                Console.WriteLine("---------------------------------");

                Equipamento novoEquipamento = new Equipamento();

                do
                {
                    Console.WriteLine("Digite o nome do equipamento: ");
                    novoEquipamento.nome = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length >= 3)
                        break;

                } while (true);

                do
                {
                    Console.WriteLine("Digite o fabricante do equipamento: ");
                    novoEquipamento.fabricante = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) && novoEquipamento.fabricante.Length >= 2)
                        break;

                } while (true);

                Console.WriteLine("Digite o preço de aquisição do equipamento: ");
                novoEquipamento.precoAquisicao = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Digite a data de fabricação do equipamento: ");
                novoEquipamento.dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                for (int i = 0; i < equipamentos.Length; i++) //percorremos todos os indíces de 0 a 99
                {
                    Equipamento? e = equipamentos[i]; //armazena o valor de cada indíce em cada iteração

                    if (e == null)
                    {
                        equipamentos[i] = novoEquipamento;
                        break; //salva apenas em uma posição
                    }
                }

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O registro \"{novoEquipamento.nome}\" foi cadastrado com sucesso.");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();


            }
            else if (opcaoMenu == "2")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Cadastro de Equipamento");
                Console.WriteLine("---------------------------------");
            }
            else if (opcaoMenu == "3")
            {
            }
            else if (opcaoMenu == "4")
            {
            }
        }
    }
}