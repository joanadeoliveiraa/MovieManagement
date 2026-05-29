using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain.Interfaces
{
    public interface IFilmeRepository
    {
        void Adicionar(Filme filme); //Adicionar filmes

        List<Filme> ObterTodos(); //Listar filmes

        Filme? ObterPorTitulo(string titulo); //procurar filme por título 

        bool Remover(int id); //remover filme 

        bool ExistePorTitulo(string titulo); // Regra: não pode existir duplicado!!!!
    }
}    