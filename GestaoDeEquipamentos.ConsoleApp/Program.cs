using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{

    static void Main(string[] args)
    {
        Equipamento?[] equipamentos = new Equipamento[100];
        TelaEquipamento telaEquipamento = new TelaEquipamento();

        while (true)
        {
            string? opcaoMenu = telaEquipamento.ObterEscolhaDoMenuPrincipal(); //recebe o retorno do método

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                telaEquipamento.Cadastrar(equipamentos);
            }
            else if (opcaoMenu == "2")
            {
                telaEquipamento.Editar(equipamentos);
            }
            else if (opcaoMenu == "3")
            {
                telaEquipamento.Excluir(equipamentos);
            }
            else if (opcaoMenu == "4")
            {
                telaEquipamento.VisualizarTodos(equipamentos);
            }
        }
    }
}