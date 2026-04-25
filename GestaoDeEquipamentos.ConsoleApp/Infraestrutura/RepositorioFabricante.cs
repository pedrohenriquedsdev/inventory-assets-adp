using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioFabricante
{
    public Fabricante?[] fabricantes = new Fabricante[100];

    public void Cadastrar(Fabricante novoFabricante)
    {
        novoFabricante.id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                fabricantes[i] = novoFabricante;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Fabricante novoEquipamento)
    {
        Fabricante? fabricanteSelecionado = SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.nome = novoEquipamento.nome;
        fabricanteSelecionado.email = novoEquipamento.email;
        fabricanteSelecionado.telefone = novoEquipamento.telefone;

        return true;
    }

    public bool Excluir(Fabricante fabricanteSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            if (f == fabricanteSelecionado)
            {
                fabricantes[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            if (f.id == idSelecionado)
            {
                fabricantes[i] = null;
                return true;
            }
        }

        return false;
    }

    public Fabricante? SelecionarPorId(string idSelecionado)
    {
        Fabricante? fabricanteSelecionado = null;

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            if (f.id == idSelecionado)
            {
                fabricanteSelecionado = f;
                break;
            }
        }

        return fabricanteSelecionado;
    }

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }
}