using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Cadastrar equipamento");
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
                
            }

            else if (opcaoMenu == "2")
            {

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