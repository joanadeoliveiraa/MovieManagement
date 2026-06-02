using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{    
    public class CategoriaRepository: ICategoriaRepository
    {
        // Lista para armazenar categorias em memória
        private List<Categoria> _categorias = new();

        // Controla o próximo Id disponível
        private int _proximoId;

        // Construtor
        public CategoriaRepository()
        {
            _categorias = new List<Categoria>();
            _proximoId = 1;
        }

        public void Adicionar(Categoria categoria) // Adiciona uma nova categoria
        {
            categoria.Id = _proximoId;
            _proximoId++;

            _categorias.Add(categoria);
        }
                
        public List<Categoria> ObterTodos() // Lista de categorias existentes
        {
            return _categorias;
        }

        public Categoria? ObterPorNome(string nome)
        {
            foreach (Categoria categoria in _categorias)
            {
                if (categoria.Nome.Contains(
                    nome,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return categoria;
                }
            }

            return null;
        }

        public bool Remover(int id) // Remove categoria pelo ID
        {
            Categoria? categoria = null;

            foreach (Categoria c in _categorias)
            {
                if (c.Id == id)
                {
                    categoria = c;
                    break;
                }
            }

            if (categoria != null)
            {
                _categorias.Remove(categoria);
                return true;
            }

            return false;
        }
                
        public bool ExistirPorNome(string nome) // Verifica se já existe categoria com esse nome
        {
            foreach (Categoria categoria in _categorias)
            {
                if (categoria.Nome.Equals(nome,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}