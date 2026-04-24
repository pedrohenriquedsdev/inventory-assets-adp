using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioEquipamento
{
    public Equipamento?[] equipamentos = new Equipamento[100];

    public void Cadastrar(Equipamento novoEquipamento)
    {
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
    }

    public bool Editar(string idSelecionado, Equipamento novoEquipamento)
    {
        Equipamento? equipamentoSelecionado = SelecionarPorID(idSelecionado); //recebe retorno do método

        if (equipamentoSelecionado == null)
            return false;

        equipamentoSelecionado.nome = novoEquipamento.nome;
        equipamentoSelecionado.fabricante = novoEquipamento.fabricante;
        equipamentoSelecionado.precoAquisicao = novoEquipamento.precoAquisicao;
        equipamentoSelecionado.dataFabricacao = novoEquipamento.dataFabricacao;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
            {
                equipamentos[i] = null;
                return true;
            }
        }

        return false;

    }
    public Equipamento? SelecionarPorID(string idSelecionado)
    {
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

        return equipamentoSelecionado; //retorna algo ou null
    }

    public Equipamento?[] SelecionarTodos()
    {
        return equipamentos;
    }
}
