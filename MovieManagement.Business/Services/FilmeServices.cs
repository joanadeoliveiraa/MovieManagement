using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Enums;
using MovieManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Business.Services
{
    public class FilmeServices
    {
        private readonly IFilmeRepository _repository; // readonly: não vai permitir alteração depois de inicializar.

        public FilmeServices(IFilmeRepository repository)
        {
            _repository = repository;
        }


        // Adiciona um filme após validar as regras de negócio
        public void Adicionar(Filme filme)
        {
            // Regra 1: O título é obrigatório
            if (string.IsNullOrWhiteSpace(filme.Titulo))
            {
                throw new Exception("O título do filme é obrigatório.");
            }

            // Regra 2: Não permitir filmes duplicados
            if (_repository.ExistePorTitulo(filme.Titulo))
            {
                throw new Exception("Já existe um filme com esse título.");
            }

            //Regra 3: A classificação deve estar entre 0 e 5
            if (!Enum.IsDefined(typeof(ClassificacaoFilme), filme.Classificacao))
            {
                throw new Exception("Classificação inválida. Deve estar entre 0 e 5.");
            }

            _repository.Adicionar(filme); //Guardar o filme
        }



        // Obtém todos os filmes
        public List<Filme> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        // Procura um filme pelo título
        public Filme? Procurar(string titulo)
        {
            return _repository.ObterPorTitulo(titulo);
        }


        // Remove um filme pelo Id
        public bool Remover(int id)
        {
            return _repository.Remover(id);
        }
    }
}
