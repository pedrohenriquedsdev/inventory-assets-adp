using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Equipamento?[] equipamentos = new Equipamento[100];

        Equipamento equipamentoTeste = new Equipamento();

        equipamentoTeste.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        equipamentoTeste.nome = "Notebook";
        equipamentoTeste.fabricante = "Acer";
        equipamentoTeste.precoAquisicao = 4000;
        equipamentoTeste.dataFabricacao = DateTime.Now;

        equipamentos[0] = equipamentoTeste;

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

                novoEquipamento.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

                for (int i = 0; i < equipamentos.Length; i++) //percorremos todos os indíces de 0 a 99
                {
                    Equipamento? e = equipamentos[i]; //referencia o valor de cada índice

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
                Console.WriteLine("Edição de Equipamento");
                Console.WriteLine("---------------------------------");

                Console.WriteLine(
                                       "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                       "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO"
                                   );

                for (int i = 0; i < equipamentos.Length; i++) //percorremos todos os indíces de 0 a 99
                {
                    Equipamento? e = equipamentos[i]; //referencia o valor de cada índice

                    if (e == null) //null guard
                        continue;

                    Console.WriteLine(
                        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                    e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
                }

                string? idSelecionado;

                do
                {
                    Console.WriteLine("Digite o ID do equipamento que deseja editar: ");
                    idSelecionado = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                        break;
                } while (true);

                Equipamento? equipamentoSelecionado = null;

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    Equipamento? e = equipamentos[i];

                    if (e == null)
                        continue;

                    if (e.id == idSelecionado)
                    {
                        equipamentoSelecionado = e;
                        break;
                    }
                }

                if (equipamentoSelecionado == null)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Não foi possível encontrar o equipamento informado.");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Digite ENTER para continuar");
                    Console.ReadLine();
                    continue;
                }

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

                equipamentoSelecionado.nome = novoEquipamento.nome;
                equipamentoSelecionado.fabricante = novoEquipamento.fabricante;
                equipamentoSelecionado.precoAquisicao = novoEquipamento.precoAquisicao;
                equipamentoSelecionado.dataFabricacao = novoEquipamento.dataFabricacao;

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();

            }
            else if (opcaoMenu == "3")
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Exclusão de Equipamento");
                Console.WriteLine("---------------------------------");

                Console.WriteLine(
                                       "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                                       "ID", "NOME", "FABRICANTE", "PREÇO DE AQUISIÇÃO", "DATA DE FABRICAÇÃO"
                                   );

                for (int i = 0; i < equipamentos.Length; i++) //percorremos todos os indíces de 0 a 99
                {
                    Equipamento? e = equipamentos[i]; //referencia o valor de cada índice

                    if (e == null) //null guard
                        continue;

                    Console.WriteLine(
                        "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
                    e.id, e.nome, e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString());
                }

                string? idSelecionado;

                do
                {
                    Console.WriteLine("Digite o ID do equipamento que deseja excluir: ");
                    idSelecionado = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                        break;
                } while (true);

                bool equipamentoExcluido = false;

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    Equipamento? e = equipamentos[i];

                    if (e == null)
                        continue;

                    if (e.id == idSelecionado)
                    {
                        equipamentos[i] = null;
                        equipamentoExcluido = true;
                        break;
                    }
                }

                if (equipamentoExcluido)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"O registro \"{idSelecionado}\" foi excluido com sucesso!");
                    Console.WriteLine("---------------------------------");
                }

                else
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"Não foi possível encontrar o registro \"{idSelecionado}\". Tente novamente!");
                    Console.WriteLine("---------------------------------");
                }

                Console.Write("Digite ENTER para continuar");
                Console.ReadLine();
            }
            else if (opcaoMenu == "4")
            {
            }
        }
    }
}