using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Business.Services
{
    public class RealizadorService
    {
        private readonly IRealizadorRepository _repository; // Referência ao repositório de realizadores

        // Construtor
        public RealizadorService(IRealizadorRepository repository)
        {
            _repository = repository;
        }

        // Adiciona um realizador após validar as regras de negócio
        public void Adicionar(Realizador realizador)
        {
            // Regra 1 - Nome obrigatório
            if (string.IsNullOrWhiteSpace(realizador.Nome))
            {
                throw new Exception("O nome do realizador é obrigatório.");
            }

            // Regra 2 - País é obrigatório
            if (string.IsNullOrWhiteSpace(realizador.Pais)) // IsNullOrWhiteSpace: país nao pode ser nulo ou em branco. Evita dados em branco
            {
                throw new Exception("O país do realizador é obrigatório.");
            }

            // Guarda o novo realizador
            _repository.Adicionar(realizador);
        }

        public List<Realizador> ObterTodos() // Obtém todas os realizadores existentes
        {
            return _repository.ObterTodos();
        }

        public Realizador? Procurar(string nome) // Procura realizador pelo nome
        {
            return _repository.ObterPorNome(nome);
        }

        public bool Remover(int id) // Remove  categoria pelo ID
        {
            return _repository.Remover(id);
        }
    }
}