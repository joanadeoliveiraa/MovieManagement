using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    
    public class RealizadorRepository:IRealizadorRepository // Implementação do "contrato"
     {
        // Lista para armazenar realizadores 
        private List<Realizador> _realizadores = new();

        // Controla o próximo Id disponível
        private int _proximoId;

        // Construtor
        public RealizadorRepository()
        {
            _realizadores = new List<Realizador>();
            _proximoId = 1;
        }
        
        public void Adicionar(Realizador realizador) // Adiciona novo realizador
        {
            realizador.Id = _proximoId;
            _proximoId++;

            _realizadores.Add(realizador);
        }
                
        public List<Realizador> ObterTodos() // Lista de todos os realizadores
        {
            return _realizadores;
        }

        public Realizador? ObterPorNome(string nome) // Procura realizador pelo nome
        {
            foreach (Realizador realizador in _realizadores)
            {
                if (realizador.Nome.Contains(nome,StringComparison.OrdinalIgnoreCase))
                {
                    return realizador;
                }
            }

            return null;
        }
                
        public bool Remover(int id) // Remove realizador pelo ID
        {
            Realizador? realizador = null;

            foreach (Realizador r in _realizadores)
            {
                if (r.Id == id)
                {
                    realizador = r;
                    break;
                }
            }

            if (realizador != null)
            {
                _realizadores.Remove(realizador);
                return true;
            }

            return false;
        }
                
        public bool ExistirPorNome(string nome) // Verifica se já existe realizador com esse nome
        {
            foreach (Realizador realizador in _realizadores)
            {
                if (realizador.Nome.Equals(nome,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}