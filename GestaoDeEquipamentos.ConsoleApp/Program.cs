using GestaoDeEquipamentos.ConsoleApp.Apresentacao;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{

    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento(); //criamos uma instância para que a program possa usar TelaEquipamento

        while (true)
        {
            string? opcaoMenu = telaEquipamento.ObterEscolhaDoMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                telaEquipamento.Cadastrar();
            }
            else if (opcaoMenu == "2")
            {
                telaEquipamento.Editar();
            }
            else if (opcaoMenu == "3")
            {
                telaEquipamento.Excluir();
            }
            else if (opcaoMenu == "4")
            {
                telaEquipamento.VisualizarTodos();
            }
        }
    }
}