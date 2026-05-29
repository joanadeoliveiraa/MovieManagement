using MovieManagement.Domain.Interfaces;
using MovieManagement.Domain.Entities;
using static System.Net.WebRequestMethods;
using System;
using System.Collections.Generic;
using System.Text;


namespace MovieManagement.Data.Repositories
{
    public class FilmeRepository:IFilmeRepository //Impletentação
    {
        private List<Filme>_filmes= new(); //Lista usada para armazenar filmes
        private int _proximoId; //Atribui Id automaticamente

        //Construtor:
        public FilmeRepository()
        {
            _filmes = new List<Filme>();
            _proximoId = 1;
        }

        //Add novo filme:
        public void Adicionar(Filme filme)
        {
            filme.Id = _proximoId; //atribui ID
            _proximoId++;

            _filmes.Add(filme); //Guardar filme na memória
        }

        //Lista filmes da memória:
        public List<Filme> ObterTodos()
        {
            return _filmes;
        }

        //Procura um filme pelo titulo
        public Filme? ObterPorTitulo(string titulo)
        {
            foreach (Filme f in _filmes)
            {
                if (f.Titulo.Contains(titulo,StringComparison.OrdinalIgnoreCase)) //Contains: desta forma, no caso de não termos a certeza do nome do filme, é possivel encontra-lo por partes do Nome.
                {
                    return f;
                }
            }

            return null;
        }

        //Remove filme:
        public bool Remover (int id)
        {
            Filme? filme = null;

            foreach (Filme f in _filmes) //procura filme na lista
            {
                if (f.Id==id)
                {
                    filme = f;
                    break;
                }
            }
            if (filme !=null)
            {
                _filmes.Remove(filme);
                return true;
            }
            return false;
        }


        //Verifica se já existe filme com o mesmo título
        public bool ExistePorTitulo(string titulo)
        {
            foreach (Filme f in _filmes)
            {
                if (f.Titulo.Equals(titulo,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }


    }
}
