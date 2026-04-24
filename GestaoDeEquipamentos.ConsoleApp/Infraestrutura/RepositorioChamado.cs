
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado?[] chamados = new Chamado[100];

    public void Cadastrar(Chamado novoChamado)
    {
        novoChamado.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++) //percorremos todos os indíces de 0 a 99
        {
            Chamado? c = chamados[i]; //referencia o valor de cada índice

            if (c == null)
            {
                chamados[i] = novoChamado;
                break; //salva apenas em uma posição
            }
        }
    }
}
