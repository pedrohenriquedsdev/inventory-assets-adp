using GestaoDeEquipamentos.ConsoleApp.Dominio;
using System.Security.Cryptography;

namespace GestaoDeChamados.ConsoleApp.Infraestrutura
{
    public class RepositorioChamado
    {
        public Chamado?[] chamados = new Chamado[100];

        public void Cadastrar(Chamado novoChamado)
        {
            novoChamado.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado? e = chamados[i];

                if (e == null)
                {
                    chamados[i] = novoChamado;
                    break;
                }

            }
        }
    }
}
