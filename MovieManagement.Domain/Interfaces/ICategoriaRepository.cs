using System;
using System.Collections.Generic;
using System.Text;
using MovieManagement.Domain.Entities;

namespace MovieManagement.Domain.Interfaces

{
    public interface ICategoriaRepository //"Contrato" que definie as operações
    {
        void Adicionar(Categoria categoria); //Adicionar nova categoria

        List<Categoria> ObterTodos(); //Lista de todas as categorias existentes

        Categoria? ObterPorNome(string nome); //Procura categoria pelo nome

        bool Remover(int id); //Remove categoria através do ID

        bool ExistirPorNome(string nome); //Verifica se a categoria já existe
    }
}
