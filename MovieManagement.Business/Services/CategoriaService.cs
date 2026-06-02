using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Business.Services
{
    public class CategoriaService
    {        
        private readonly ICategoriaRepository _repository; // Referência ao repositório de categorias

        // Construtor
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        // Adiciona uma categoria após validar as regras de negócio
        public void Adicionar(Categoria categoria)
        {
            // Regra 1 - Nome obrigatório
            if (string.IsNullOrWhiteSpace(categoria.Nome))
            {
                throw new Exception("O nome da categoria é obrigatório.");
            }

            // Regra 2 - Não permitir categorias duplicadas
            if (_repository.ExistirPorNome(categoria.Nome))
            {
                throw new Exception("Já existe uma categoria com esse nome.");
            }

            // Guarda a categoria
            _repository.Adicionar(categoria);
        }

        public List<Categoria> ObterTodos() // Obtém todas as categorias existentes
        {
            return _repository.ObterTodos();
        }

        public Categoria? Procurar(string nome) // Procura categoria pelo nome
        {
            return _repository.ObterPorNome(nome);
        }
                
        public bool Remover(int id) // Remove  categoria pelo ID
        {
            return _repository.Remover(id);
        }
    }
}