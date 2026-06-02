using System;
using System.Collections.Generic;
using System.Text;
using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.Interfaces
{
    public interface IRealizadorRepository // Contrato que define as operações
    {
        void Adicionar(Realizador realizador); // Adiciona um novo realizador

        List<Realizador> ObterTodos(); //Lista de realizadores existentes

        Realizador? ObterPorNome(string nome); //Procura realizador por nome

        bool Remover(int id); //Remove realizador por ID
        bool ExistirPorNome(string nome); //Verifica se realizador já faz parte da litsa
    }
}
