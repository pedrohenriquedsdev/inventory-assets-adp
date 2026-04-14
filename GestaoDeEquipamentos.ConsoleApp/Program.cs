using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Equipamento?[] equipamentos = new Equipamento[100]; //array de objetos
        TelaEquipamento telaEquipamento = new TelaEquipamento(); //para usar os métodos da class

        while (true)
        {
            string? opcaoMenu = telaEquipamento.ObterEscolhaDoMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaEquipamento.Cadastrar(equipamentos);
            
            else if (opcaoMenu == "2")
                telaEquipamento.Editar(equipamentos);

            else if (opcaoMenu == "3")
            {
                telaEquipamento.Excluir(equipamentos);
            }

            else if (opcaoMenu == "4")
            {
                telaEquipamento.Visualizar(equipamentos);
            }
        }
    }
}